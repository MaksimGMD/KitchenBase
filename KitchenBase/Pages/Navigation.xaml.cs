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

namespace KitchenBase.Pages
{
    /// <summary>
    /// Логика взаимодействия для Navigation.xaml
    /// </summary>
    public partial class Navigation : Window
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void btProductsWeight_Click(object sender, RoutedEventArgs e)
        {            
            ProductsWeight ProductsWeight = new ProductsWeight();
            ProductsWeight.Show();
            Close();
        }

        private void btPosition_Click(object sender, RoutedEventArgs e)
        {
            Positions positions = new Positions();
            positions.Show();
            Close();
        }

        private void btMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu Menu = new Menu();
            Menu.Show();
            Close();
        }

        private void btTypeProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductsType ProductsType = new ProductsType();
            ProductsType.Show();
            Close();
        }

        private void btInformationStuff_Click(object sender, RoutedEventArgs e)
        {
            Stuff Stuff = new Stuff();
            Stuff.Show();
            Close();
        }

        private void btInformationCustomers_Click(object sender, RoutedEventArgs e)
        {
            Customers Customers = new Customers();
            Customers.Show();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            switch (MessageBox.Show("Покинуть приложение?", "KitchenBase", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                case MessageBoxResult.Yes:
                    e.Cancel = false;
                    break;
                case MessageBoxResult.No:
                    e.Cancel = true;
                    break;
            }
            Authorization Authorization = new Authorization();
            Authorization.Show();

        }
    }
}
