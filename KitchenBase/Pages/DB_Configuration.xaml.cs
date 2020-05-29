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
using System.Data;
using System.Threading;
using System.Windows.Forms;



namespace KitchenBase.Pages
{
    /// <summary>
    /// Логика взаимодействия для DB_Configuration.xaml
    /// </summary>
    public partial class DB_Configuration : Window
    {
        public DB_Configuration()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Вызов класса конфигурации
            Classes.Configuration_class configuration
                = new Classes.Configuration_class();
            //Присвоение event action события
            configuration.Server_Collection
                += Configuration_Server_Collection; 
            //Обяхвление экземпляра потока
            Thread threadServers =
                new Thread(configuration.SQL_Server_Enumuretor);
            //Запуск потока
            threadServers.Start();
        }

        private void Configuration_Server_Collection(DataTable obj)
        {
            //Вызов делегата для присвоения в него фрагмента кода
            //Через лямбда выражение => в делегат приваиватся код
            Action action = () =>
            {
                //Для каждой строки таблицы в выпадающий список 
                //Дополнить колекцию пунктов Server Name\Machine Name
                foreach (DataRow r in obj.Rows)
                {
                    cbServerName.Items.Add(string.Format(@"{0}\{1}", r[0], r[1]));
                }
                cbServerName.IsEnabled = true;
                btChecked.IsEnabled = true;
            };
            //Присвоение фонового потока в основной
            Dispatcher.Invoke(action);
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbServerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Classes.Configuration_class configuration
             = new Classes.Configuration_class();
            configuration.ds = cbServerName.SelectedItem.ToString();
            configuration.Connection_Checked
                += Configuration_Conection_Checked;
            Thread thread
                = new Thread(configuration.SQL_Data_Base_Checking);
            thread.Start();
        }

        private void Configuration_Conection_Checked(bool obj)
        {
            switch (obj)
            {
                //Если подключение выполнено верно то появляется сообщение
                case true:
                    System.Windows.Forms.MessageBox.Show("Проверка выполнена!");
                    Action action = () =>
                    {
                        //Повторение метода выбора
                        Classes.Configuration_class configuration_coll
                            = new Classes.Configuration_class();
                        configuration_coll.Data_Base_Collection
                            += Configuration_Data_Base_Collection;
                        Thread threadBases
                            = new Thread(configuration_coll.SQL_Data_Base_Collection);
                        threadBases.Start();
                        btConnect.IsEnabled = true;
                    };
                    Dispatcher.Invoke(action);
                    break;
                case false:
                    //Вслучае если  нет подключения повторяем сбор данных
                    //о сервере
                    Classes.Configuration_class configuration
                        = new Classes.Configuration_class();
                    configuration.Server_Collection
                        += Configuration_Server_Collection;
                    Thread threadServers
                        = new Thread(configuration.SQL_Server_Enumuretor);
                    threadServers.Start();
                    break;
            }
        }

        private void Configuration_Data_Base_Collection(DataTable obj)
        {
            Action action = () =>
            {
                foreach (DataRow r in obj.Rows)
                {
                   //cbDataBaseName.Items.Add(r[0]);
                }
                cbDataBaseName.IsEnabled = true;
                btChecked.IsEnabled = true;
            };
            Dispatcher.Invoke(action);
        }

        //Кнопка проверка подключения к источнику и базе данных
        private void btChecked_Click(object sender, RoutedEventArgs e)
        {
            System.Data.SqlClient.SqlConnection sql
             = new System.Data.SqlClient.SqlConnection(
            string.Format("Data Source = {0}; Initial Catalog =" +
            " {1}; Integrated Security = true;", cbServerName.Text,
            cbDataBaseName.Text));
            try
            {
                sql.Open();
                btConnect.IsEnabled = true;
            }
            catch
            {

            }
            finally
            {
                sql.Close();
            }
        }

        //Подключение к источнику данныфх
        private void btConnect_Click(object sender, RoutedEventArgs e)
        {
            switch (cbDataBaseName.Text == "")
            {
                case true:
                    //В случае если поле не заполнено
                    System.Windows.MessageBox.Show("Не выбрана нужная база данных!",
                        "Продажа товара",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    cbDataBaseName.Focus();
                    break;
                case false:
                    Classes.Configuration_class configuration
                        = new Classes.Configuration_class();
                    //Присвоение конфигурации в реестр ОС
                    configuration.SQL_Server_Configuration_Set(
                        cbDataBaseName.Text, cbDataBaseName.Text);
                    //Присвоение в переменную значение 
                    //о правильности подключения
                    Authorization.connect = true;
                    //Перезапуск программы
                    System.Windows.Forms.Application.Restart();
                    //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    //Application.Current.Shutdown();
                    break;
            }
        }


    }
}
