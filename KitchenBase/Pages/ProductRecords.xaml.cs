using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Xml;
using System.Xml.Xsl;
using KitchenBase.Classes;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

namespace KitchenBase.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductRecords.xaml
    /// </summary>
    public partial class ProductRecords : System.Windows.Window
    {

        DataProcedure DataProcedure = new DataProcedure();
        private string QR = "";
        public ProductRecords()
        {
            InitializeComponent();
        }

        //DataProcedure procedure = new DataProcedure();

        private void cbTypeProductFill()
        {
            DBConnection connection = new DBConnection();
            connection.TypeProductFill();
            cbTypeProduct.ItemsSource = connection.dtTypeProduct.DefaultView;
            cbTypeProduct.SelectedValuePath = "ID_TypeProduct";
            cbTypeProduct.DisplayMemberPath = "Название типа продукта";
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

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgYchetProductovNaSklade.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[6].ToString() == tbSearch.Text)
                {
                    dgYchetProductovNaSklade.SelectedItem = dataRow;
                }
            }
        }

        private void btFilter_Click(object sender, RoutedEventArgs e)
        {
            string newQR = QR + "where [NameProduct] like '%" + tbSearch.Text + "%' or [VesProducta] like '%" + tbSearch.Text + "%' or [KolichestvoNaSklade] like '%" + tbSearch.Text + "%' " +
            " or [SrokGodnosti] like '%" + tbSearch.Text + "%' or [TypeProduct] like '%" + tbSearch.Text + "%'";
            dgFill(newQR);
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = "";
            dgFill(QR);
        }

        public void Message()
        {
            MessageBox.Show("Поле не может быть пустым!! " +
             "\n Заполните все поля и попробуйте снова!", "KitchenBase",
             MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            switch (tbNameProduct.Text == "")
            {
                case (true):
                    Message();
                    tbNameProduct.Background = Brushes.Red;
                    break;
                case (false):
                    tbNameProduct.Background = Brushes.White;
                    switch (tbWeightProduct.Text == "")
                    {
                        case (true):
                            Message();
                            tbWeightProduct.Background = Brushes.Red;
                            break;
                        case (false):
                            tbWeightProduct.Background = Brushes.White;
                            switch (tbQuantityStock.Text == "")
                            {
                                case (true):
                                    Message();
                                    tbQuantityStock.Background = Brushes.Red;
                                    break;
                                case (false):
                                    tbQuantityStock.Background = Brushes.White;
                                    switch (tbShelfLife.Text == "")
                                    {
                                        case (true):
                                            Message();
                                            tbShelfLife.Background = Brushes.Red;
                                            break;
                                        case (false):
                                            tbShelfLife.Background = Brushes.White;
                                            switch (cbTypeProduct.SelectedIndex == -1)
                                            {
                                                case (true):
                                                    Message();
                                                    cbTypeProduct.Background = Brushes.Red;
                                                    break;
                                                case (false):
                                                    cbTypeProduct.Background = Brushes.White;
                                                    DataProcedure.spYchetProductovNaSklade_insert(tbNameProduct.Text.ToString(), tbWeightProduct.Text.ToString(), tbQuantityStock.Text.ToString(), tbShelfLife.Text.ToString(),
                                                        Convert.ToInt32(cbTypeProduct.SelectedValue.ToString()));
                                                    dgFill(QR);
                                                    cbTypeProductFill();
                                                    tbNameProduct.Text = "";
                                                    tbWeightProduct.Text = "";
                                                    tbQuantityStock.Text = "";
                                                    tbShelfLife.Text = "";
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            switch (tbNameProduct.Text == "")
            {
                case (true):
                    Message();
                    tbNameProduct.Background = Brushes.Red;
                    break;
                case (false):
                    tbNameProduct.Background = Brushes.White;
                    switch (tbWeightProduct.Text == "")
                    {
                        case (true):
                            Message();
                            tbWeightProduct.Background = Brushes.Red;
                            break;
                        case (false):
                            tbWeightProduct.Background = Brushes.White;
                            switch (tbQuantityStock.Text == "")
                            {
                                case (true):
                                    Message();
                                    tbQuantityStock.Background = Brushes.Red;
                                    break;
                                case (false):
                                    tbQuantityStock.Background = Brushes.White;
                                    switch (tbShelfLife.Text == "")
                                    {
                                        case (true):
                                            Message();
                                            tbShelfLife.Background = Brushes.Red;
                                            break;
                                        case (false):
                                            tbShelfLife.Background = Brushes.White;
                                            switch (cbTypeProduct.SelectedIndex == -1)
                                            {
                                                case (true):
                                                    Message();
                                                    cbTypeProduct.Background = Brushes.Red;
                                                    break;
                                                case (false):
                                                    cbTypeProduct.Background = Brushes.White;
                                                    DataRowView ID = (DataRowView)dgYchetProductovNaSklade.SelectedItems[0];
                                                    DataProcedure.spYchetProductovNaSklade_update(Convert.ToInt32(ID["ID_Producta"]), tbNameProduct.Text.ToString(), tbWeightProduct.Text.ToString(), tbQuantityStock.Text.ToString(), tbShelfLife.Text.ToString(),
                                                        Convert.ToInt32(cbTypeProduct.SelectedValue.ToString()));
                                                    dgFill(QR);
                                                    cbTypeProductFill();
                                                    tbNameProduct.Text = "";
                                                    tbWeightProduct.Text = "";
                                                    tbQuantityStock.Text = "";
                                                    tbShelfLife.Text = "";
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgYchetProductovNaSklade.SelectedItems[0];
            switch (MessageBox.Show("Хотите удалить запись?", "Удаление!", MessageBoxButton.OKCancel, MessageBoxImage.Question))
            {
                case MessageBoxResult.OK:
                    DataProcedure.spYchetProductovNaSklade_delete(Convert.ToInt32(ID["ID_Producta"]));
                    dgFill(QR);
                    cbTypeProductFill();
                    tbNameProduct.Text = "";
                    tbWeightProduct.Text = "";
                    tbQuantityStock.Text = "";
                    tbShelfLife.Text = "";
                    break;
            }
        }

        private void btCreatingBillLading_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
