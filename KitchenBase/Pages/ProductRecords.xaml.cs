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
    /// Логика взаимодействия для ProductRecords.xaml
    /// </summary>
    public partial class ProductRecords : Window
    {
        public ProductRecords()
        {
            InitializeComponent();
        }
        private string QR = "";

        //DataProcedure procedure = new DataProcedure();

        private void cbTypeProductFill()
        {
            DBConnection connection = new DBConnection();
            connection.YchetProductovNaSkladeFill();
            cbTypeProduct.ItemsSource = connection.dtYchetProductovNaSklade.DefaultView;
            cbTypeProduct.SelectedValuePath = "ID_TypeProduct";
            cbTypeProduct.DisplayMemberPath = "НазваниеТипаПродукта";
            cbTypeProduct.SelectedIndex = 1;
        }

        private void dgFill(string qr)
        {
            DBConnection connection = new DBConnection();
            DBConnection.qrYchetProductovNaSklade = qr;
            connection.YchetProductovNaSkladeFill();
            dgYchetProductovNaSklade.ItemsSource = connection.dtYchetProductovNaSklade.DefaultView;
            dgYchetProductovNaSklade.Columns[0].Visibility = Visibility.Collapsed;
            dgYchetProductovNaSklade.Columns[5].Visibility = Visibility.Collapsed;

        }

        private void dgYchetProductovNaSklade_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("NameProduct"):
                    e.Column.Header = "НаименованиеПродукта";
                    break;
                case ("TypeProduct"):
                    e.Column.Header = "НазваниеТипаПродукта";
                    break;
                case ("VesProducta"):
                    e.Column.Header = "ВесПродукта";
                    break;
                case ("KolichestvoNaSklade"):
                    e.Column.Header = "КоличествоНаСкладе";
                    break;
                case ("SrokGodnosti"):
                    e.Column.Header = "СрокГодности";
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrYchetProductovNaSklade;
            dgFill(QR);
            cbTypeProductFill();
        }
    }
}
