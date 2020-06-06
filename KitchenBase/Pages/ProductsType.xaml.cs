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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using KitchenBase.Classes;
using System.Data;


namespace KitchenBase.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsType.xaml
    /// </summary>
    public partial class ProductsType : Window
    {
        DataProcedure procedures = new DataProcedure();
        public ProductsType()
        {
            InitializeComponent();
        }
        private string QR = "";

        //DataProcedure procedure = new DataProcedure();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrTypeProduct;
            dgFill(QR);
        }


        private void dgFill(string qr)
        {
            DBConnection connection = new DBConnection();
            DBConnection.qrTypeProduct = qr;
            connection.TypeProductFill();
            dgTypeProduct.ItemsSource = connection.dtTypeProduct.DefaultView;
            dgTypeProduct.Columns[0].Visibility = Visibility.Collapsed;

        }

        private void DgTypeProduct_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("TypeProduct"):
                    e.Column.Header = "НазваниеТипаПродукта";
                    break;
            }

        }



        private void btnRightMenuHide_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideRightMenu", btnRightMenuHide, btnRightMenuShow, pnlRightMenu);
        }

        private void btnRightMenuShow_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowRightMenu", btnRightMenuHide, btnRightMenuShow, pnlRightMenu);
        }

        private void ShowHideMenu(string Storyboard, Button btnHide, Button btnShow, StackPanel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnHide.Visibility = Visibility.Visible;
                btnShow.Visibility = Visibility.Hidden;

            }
            else if (Storyboard.Contains("Hide"))
            {
                btnHide.Visibility = Visibility.Hidden;
                btnShow.Visibility = Visibility.Visible;

            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz = (Brush)converter.ConvertFromString("#20202A");
            Background = azaz;
        }


        public void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz1 = (Brush)converter.ConvertFromString("#191970");
            Background = azaz1;

        }

        public void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz2 = (Brush)converter.ConvertFromString("#696969");
            Background = azaz2;
        }

        public void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz3 = (Brush)converter.ConvertFromString("#6c43af");
            btInsert.Background = azaz3;
            btUpdate.Background = azaz3;
            btDelete.Background = azaz3;
            btSearch.Background = azaz3;
            btFilter.Background = azaz3;
            btCancel.Background = azaz3;
            btnRightMenuShow.Background = azaz3;
            Home.Background = azaz3;
            btnRightMenuHide.Background = azaz3;
            pnlRight.Background = azaz3;
        }

        public void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz4 = (Brush)converter.ConvertFromString("#000000");
            btInsert.Background = azaz4;
            btUpdate.Background = azaz4;
            btDelete.Background = azaz4;
            btSearch.Background = azaz4;
            btFilter.Background = azaz4;
            btCancel.Background = azaz4;
            btnRightMenuShow.Background = azaz4;
            Home.Background = azaz4;
            btnRightMenuHide.Background = azaz4;
            pnlRight.Background = azaz4;
        }

        public void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz5 = (Brush)converter.ConvertFromString("#006400");
            btInsert.Background = azaz5;
            btUpdate.Background = azaz5;
            btDelete.Background = azaz5;
            btSearch.Background = azaz5;
            btFilter.Background = azaz5;
            btCancel.Background = azaz5;
            btnRightMenuShow.Background = azaz5;
            Home.Background = azaz5;
            btnRightMenuHide.Background = azaz5;
            pnlRight.Background = azaz5;
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz6 = (Brush)converter.ConvertFromString("#FFFFFFFF");
            var blackz = (Brush)converter.ConvertFromString("#000000");
            tbSearch.Background = azaz6;
            tbNameType.Background = azaz6;
            tbSearch.Foreground = blackz;
            tbNameType.Foreground = blackz;
        }

        private void RadioButton_Checked_6(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz7 = (Brush)converter.ConvertFromString("#00000000");
            var whitez = (Brush)converter.ConvertFromString("#FFFFFF");
            tbSearch.Background = azaz7;
            tbNameType.Background = azaz7;
            tbSearch.Foreground = whitez;
            tbNameType.Foreground = whitez;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Navigation Navigation = new Navigation();
            Navigation.Show();
            Close();
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            dgFill(QR);
            foreach (DataRowView dataRow in (DataView)dgTypeProduct.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text)
                {
                    dgTypeProduct.SelectedItem = dataRow;
                }
            }
        }

        private void btFilter_Click(object sender, RoutedEventArgs e)
        {
            string newQR = QR + "where [TypeProduct] like '%" + tbSearch.Text + "%'";
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

        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            switch (tbNameType.Text == "")
            {
                case (true):
                    Message();
                    tbNameType.Background = Brushes.Red;
                    break;
                case (false):
                    tbNameType.Background = Brushes.White;
                    procedures.spTypeProduct_insert(tbNameType.Text.ToString());
                    dgFill(QR);
                    tbNameType.Text = "";
                    break;
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            switch (tbNameType.Text == "")
            {
                case (true):
                    Message();
                    tbNameType.Background = Brushes.Red;
                    break;
                case (false):
                    tbNameType.Background = Brushes.White;                  
                    DataRowView ID = (DataRowView)dgTypeProduct.SelectedItems[0];
                    procedures.spTypeProduct_update(Convert.ToInt32(ID["ID_TypeProduct"]), tbNameType.Text.ToString());
                    dgFill(QR);
                    tbNameType.Text = "";
                    break;
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgTypeProduct.SelectedItems[0];
            switch (MessageBox.Show("Хотите удалить запись?", "Удаление!", MessageBoxButton.OKCancel, MessageBoxImage.Question))
            {
                case MessageBoxResult.OK:
                    procedures.spTypeProduct_delete(Convert.ToInt32(ID["ID_TypeProduct"]));
                    dgFill(QR);
                    tbNameType.Text = "";
                break;
            }
            
        }
    }
}
