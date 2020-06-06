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
        //    QR = DBConnection.qrRabotaKuhni;
        //    dgFill(QR);
        }

        //private void DgTypeProduct_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        //{
        //    switch (e.Column.Header)
        //    {
        //        case ("TypeProduct"):
        //            e.Column.Header = "НазваниеТипаПродукта";
        //            break;
        //    }

        //}

        //private void dgFill(string qr)
        //{
        //    DBConnection connection = new DBConnection();
        //    DBConnection.qrRabotaKuhni = qr;
        //    connection.RabotaKuhniFill();
        //    dgOrderDetails.ItemsSource = connection.dtOrderMore_View.DefaultView;
        //    //dgOrderDetails.Columns[0].Visibility = Visibility.Collapsed;

        //}

    }
}
