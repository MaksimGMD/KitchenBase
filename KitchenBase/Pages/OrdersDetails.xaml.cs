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

namespace KitchenBase.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersDetails.xaml
    /// </summary>
    public partial class OrdersDetails : Window
    {
        private string QR = "";
        public OrdersDetails()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz7 = (Brush)converter.ConvertFromString("#00000000");
            tbOrderNumber.Background = azaz7;
            tbOrderTime.Background = azaz7;
            tbNumberTable.Background = azaz7;
            QR = DBConnection.qrRabotaKuhni;
            dgFill(QR);
        }

        private void DgTypeProduct_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                
                case ("NomerZakaza"):
                    e.Column.Header = "Номер заказа";
                    break;
                case ("VremyZakaza"):
                    e.Column.Header = "Время заказа";
                    break;
                case ("ID_Stola"):
                    e.Column.Header = "Номер стола";
                    break;
                case ("NameBluda"):
                    e.Column.Header = "Название блюда";
                    break;
                case ("KolichestvoBlud"):
                    e.Column.Header = "Количество блюд";
                    break;
                case ("TimePrigorovleniy"):
                    e.Column.Header = "Время приготовления";
                    break;
            }

        }

        private void dgFill(string qr)
        {
            DBConnection connection = new DBConnection();
            DBConnection.qrRabotaKuhni = qr;
            connection.RabotaKuhniFill();
            dgOrderDetails.ItemsSource = connection.dtOrderMore_View.DefaultView;
            dgOrderDetails.Columns[0].Visibility = Visibility.Collapsed;
            dgOrderDetails.Columns[1].Visibility = Visibility.Collapsed;
            dgOrderDetails.Columns[2].Visibility = Visibility.Collapsed;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Navigation Navigation = new Navigation();
            Navigation.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
