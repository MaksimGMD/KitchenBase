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
using System.Data.SqlClient;

namespace KitchenBase.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        private string QR = "";
        //Определяет есть подключение к БД или нет
        public Authorization()
        {
            InitializeComponent();
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
                    if (tbPassword.Text.ToString() == Crypt.Decrypt(Password))
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
                                Visibility = Visibility.Collapsed; ;
                                break;
                            //Официант
                            case ("3"):
                                tbLogin.Background = Brushes.Red;
                                tbPassword.Background = Brushes.Red;
                                lblAuthoriCheck.Visibility = Visibility.Visible;
                                break;
                            //Повар
                            case ("4"):
                                //Добавить страницу для повара
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
