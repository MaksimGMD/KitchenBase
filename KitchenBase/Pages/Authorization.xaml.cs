using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KitchenBase.Classes;
using Crypt_Library;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace KitchenBase.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
           //Определяет есть подключение к БД или нет
        public Authorization()
        {
            try
            {
                Assembly.LoadFrom("Crypt_Library.dll");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка. Не обнаружена библиотека Crypt_Library.dll. Приложение будет закрыто", "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(-1);
            }
            InitializeComponent();
           
        }
        bool startup = true;
        private void SystemCheck()
        {
            int Major = Environment.OSVersion.Version.Major;
            int Minor = Environment.OSVersion.Version.Minor;
            if ((Major >= 6) && (Minor >= 0))
            {
                RegistryKey registrySQL =
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
                RegistryKey registryNET =
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\.NETFramework");
                RegistryKey registryWord =
                Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Office\16.0\Word");
                RegistryKey registryEdge =
                Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\MicrosoftEdge");
                RegistryKey registryChrome =
                Registry.CurrentUser.OpenSubKey(@"Software\Google\Chrome");
                RegistryKey registryExcel =
                    Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Office\Excel");

                if (registrySQL == null)
                {
                    MessageBox.Show("Программа не может быть запущенна, так как в системе отсутствует Microsoft SQL Server");
                    startup = false;
                }
                else if (registryNET == null)
                {
                    MessageBox.Show("Программа не может быть запущенна, так как в системе отсутствует .NETFramework");
                    startup = false;
                }
                else if (registryWord == null)
                {
                    MessageBox.Show("Программа не может быть запущена, так как  в системе отсутствует Microsoft Word");
                    startup = false;
                }
                else if (registryExcel == null)
                {
                    MessageBox.Show("Программа не может быть запущена, так как в системе отсутствует Microsoft Excel");
                    startup = false;
                }
                else if (registryEdge == null)
                {
                    MessageBox.Show("Программа не может быть запущена, так как в системе отсутствует Microsoft Edge");
                    startup = false;
                }
                else if (registryChrome == null)
                {
                    MessageBox.Show("Программа не может быть запущена, так как в системе отсутствует брауер Google Chrome");
                    startup = false;
                }
                else
                {
                    try
                    {
                        DBConnection.connection.Open();
                    }
                    catch
                    {
                        MessageBox.Show("Не возможно подключиться к источнику данных");
                        startup = false;
                    }
                    finally
                    {
                        DBConnection.connection.Close();
                    }
                }

                RegistryKey freckey = Registry.LocalMachine;
                freckey = freckey.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0", false);
                string str = freckey.GetValue("~MHz").ToString();             
                if (Convert.ToInt32(str) <= 1000)
                {
                    MessageBox.Show(String.Format("Очень низкая тактовая частота процессора: {0}", str));
                    startup = false;
                }
                double free = 0;
                double a = 0;
                string Vol = "";
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                foreach (DriveInfo MyDriveInfo in allDrives)
                {
                    if (MyDriveInfo.IsReady == true)
                    {
                        free = MyDriveInfo.AvailableFreeSpace;
                        a = (free / 1024) / 1024;
                        Vol += MyDriveInfo.Name + ": " + a.ToString("#.##") + Environment.NewLine;
                    }
                }
                if (a < 1000)
                {
                    MessageBox.Show("Недостаточно памяти на жёстком диске");
                    startup = false;
                }
            }
            else
            {
                MessageBox.Show("Невозможно запустить приложение на данной Операционной системе.");
            }
        }


        //Авторизация
        private void btAccept_Click(object sender, RoutedEventArgs e)
        {
            string Password;
            DBConnection connection = new DBConnection();
            connection.Authorization(tbLogin.Text);
            switch (DBConnection.idUser)
            {
                case (0):
                    tbLogin.Background = Brushes.Red;
                    tbPassword.Background = Brushes.Red;
                    lblAuthoriCheck.Visibility = Visibility.Visible;
                    break;
                default:
                    //Проверка пароля
                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                    command.CommandText = "select [Password] from [Authorization] where [ID_Authorization] = '" + DBConnection.idUser + "'";
                    DBConnection.connection.Open();
                    Password = command.ExecuteScalar().ToString(); //Строка (пароль) из базы данных
                    DBConnection.connection.Close();
                    if (tbPassword.Password.ToString() == Crypt.Decrypt(Password))
                    {
                        //Проверка должности
                        switch (connection.userDoljnost(DBConnection.idUser))
                        {
                            //Администратор
                            case ("1"):
                                Navigation Navigation = new Navigation();
                                Navigation.Show();
                                Visibility = Visibility.Collapsed;
                                break;
                            //Кладовщик
                            case ("2"):
                                ProductRecords ProductRecords = new ProductRecords();
                                ProductRecords.Show();
                                Visibility = Visibility.Collapsed;
                                break;
                            //Официант
                            case ("3"):
                                tbLogin.Background = Brushes.Red;
                                tbPassword.Background = Brushes.Red;
                                lblAuthoriCheck.Visibility = Visibility.Visible;
                                break;
                        }
                        break;
                    }
                    else
                    {
                        tbLogin.Background = Brushes.White;
                        tbPassword.Background = Brushes.White;
                        lblAuthoriCheck.Visibility = Visibility.Hidden;
                    }
                    break;
            }
        }
    }
}
