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
using KitchenBase.Pages;
using KitchenBase.Classes;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace KitchenBase.Pages
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        DataProcedure DataProcedure = new DataProcedure();
        private SqlCommand command
           = new SqlCommand("", DBConnection.connection);
        private string QR = "";
        public Menu()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrMenu;
            dgFill(QR);
            cbFill();
            cbFill2();
        }

        private void dgFill(string qr)
        {
            DBConnection connection = new DBConnection();
            DBConnection.qrMenu = qr;
            connection.MenuFill();
            dgMenu.ItemsSource = connection.dtMenu.DefaultView;
            dgMenu.Columns[0].Visibility = Visibility.Collapsed;
            dgMenu.Columns[4].Visibility = Visibility.Collapsed;
            dgMenu.Columns[5].Visibility = Visibility.Collapsed;
            dgMenu.Columns[7].Visibility = Visibility.Collapsed;
        }

        private void cbFill()
        {
            DBConnection connection = new DBConnection();
            connection.YchetProductovNaSkladeFill();
            cbNameProducta.ItemsSource = connection.dtYchetProductovNaSklade.DefaultView;
            cbNameProducta.SelectedValuePath = "ID_Producta";
            cbNameProducta.DisplayMemberPath = "Наименование продукта";
        }

        private void cbFill2()
        {
            DBConnection connection = new DBConnection();
            connection.SostavaBludaFill();
            cbVesProducta.ItemsSource = connection.dtSostavaBluda.DefaultView;
            cbVesProducta.SelectedValuePath = "ID_SostavaBluda";
            cbVesProducta.DisplayMemberPath = "Вес продукта";
        }

        private void dgMenu_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("NameBluda"):
                    e.Column.Header = "Наименование блюда";
                    break;
                case ("TimePrigorovleniy"):
                    e.Column.Header = "Время приготовления";
                    break;
                case ("CenaBluda"):
                    e.Column.Header = "Цена блюда";
                    break;
                case ("NameProduct"):
                    e.Column.Header = "Название продукта";
                    break;
                case ("VesProducta"):
                    e.Column.Header = "Вес продукта";
                    break;
            }
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgMenu.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[6].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[8].ToString() == tbSearch.Text)
                {
                    dgMenu.SelectedItem = dataRow;
                }
            }
        }

        private void btFilter_Click(object sender, RoutedEventArgs e)
        {
            string newQR = QR + "where [NameBluda] like '%" + tbSearch.Text + "%' or [TimePrigorovleniy] like '%" + tbSearch.Text + "%' or [CenaBluda] like '%" + tbSearch.Text + "%' " +
                " or [NameProduct] like '%" + tbSearch.Text + "%' or [VesProducta] like '%" + tbSearch.Text + "%'";
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
        
        public static string qrSQL = "SELECT [NameBluda] FROM [Menu]";
        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            switch (tbNameBluda.Text == "")
            {
                case (true):
                    Message();
                    tbNameBluda.Background = Brushes.Red;
                    break;
                case (false):
                    tbNameBluda.Background = Brushes.White;
                    switch (tbTime.Text == "")
                    {
                        case (true):
                            Message();
                            tbTime.Background = Brushes.Red;
                            break;
                        case (false):
                            tbTime.Background = Brushes.White;
                            switch (tbCena.Text == "")
                            {
                                case (true):
                                    Message();
                                    tbCena.Background = Brushes.Red;
                                    break;
                                case (false):
                                    tbCena.Background = Brushes.White;
                                    switch (cbNameProducta.SelectedIndex == -1)
                                    {
                                        case (true):
                                            Message();
                                            cbNameProducta.Background = Brushes.Red;
                                            break;
                                        case (false):
                                            cbNameProducta.Background = Brushes.White;
                                            switch (cbVesProducta.SelectedIndex == -1)
                                            {
                                                case (true):
                                                    Message();
                                                    cbVesProducta.Background = Brushes.Red;
                                                    break;
                                                case (false):
                                                    cbVesProducta.Background = Brushes.White;
                                                    DBConnection connection = new DBConnection();                                                    
                                                        if (connection.MenuFind(tbNameBluda.Text) > 0)
                                                        {
                                                            DataRowView ID = (DataRowView)dgMenu.SelectedItems[0];
                                                            DataProcedure.spIngridient_insert(Convert.ToInt32(ID["ID_Menu"]), Convert.ToInt32(cbNameProducta.SelectedValue.ToString()), Convert.ToInt32(cbVesProducta.SelectedValue.ToString()));
                                                        }
                                                        else
                                                        {
                                                            DataProcedure.spMenu_insert(tbNameBluda.Text.ToString(), tbTime.Text.ToString(), tbCena.Text.ToString());
                                                           DataProcedure.spIngridient_insert(0, Convert.ToInt32(cbNameProducta.SelectedValue.ToString()), Convert.ToInt32(cbVesProducta.SelectedValue.ToString()));
                                                        }                                                                        
                                                    dgFill(QR);
                                                    tbNameBluda.Text = "";
                                                    tbTime.Text = "";
                                                    tbCena.Text = "";
                                                    cbFill();
                                                    cbFill2();
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

        public static string intID = "";
        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            switch (tbNameBluda.Text == "")
            {
                case (true):
                    Message();
                    tbNameBluda.Background = Brushes.Red;
                    break;
                case (false):
                    tbNameBluda.Background = Brushes.White;
                    switch (tbTime.Text == "")
                    {
                        case (true):
                            Message();
                            tbTime.Background = Brushes.Red;
                            break;
                        case (false):
                            tbTime.Background = Brushes.White;
                            switch (tbCena.Text == "")
                            {
                                case (true):
                                    Message();
                                    tbCena.Background = Brushes.Red;
                                    break;
                                case (false):
                                    tbCena.Background = Brushes.White;
                                    switch (cbNameProducta.SelectedIndex == -1)
                                    {
                                        case (true):
                                            Message();
                                            cbNameProducta.Background = Brushes.Red;
                                            break;
                                        case (false):
                                            cbNameProducta.Background = Brushes.White;
                                            switch (cbVesProducta.SelectedIndex == -1)
                                            {
                                                case (true):
                                                    Message();
                                                    cbVesProducta.Background = Brushes.Red;
                                                    break;
                                                case (false):
                                                    cbVesProducta.Background = Brushes.White;
                                                    DataRowView ID = (DataRowView)dgMenu.SelectedItems[0];
                                                    DataProcedure.spMenu_update(Convert.ToInt32(ID["ID_Menu"]), tbNameBluda.Text.ToString(), tbTime.Text.ToString(), tbCena.Text.ToString());
                                                    DataProcedure.spIngridient_update(Convert.ToInt32(ID["ID_Ingridientov"]), Convert.ToInt32(ID["ID_Menu"]), Convert.ToInt32(cbNameProducta.SelectedValue.ToString()), Convert.ToInt32(cbVesProducta.SelectedValue.ToString()));
                                                    dgFill(QR);
                                                    tbNameBluda.Text = "";
                                                    tbTime.Text = "";
                                                    tbCena.Text = "";
                                                    cbFill();
                                                    cbFill2();
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
           
            DataRowView ID = (DataRowView)dgMenu.SelectedItems[0];
            switch (MessageBox.Show("Удалить блюдо", "Удаление!", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
            {
                case MessageBoxResult.Yes:
                    DataProcedure.spMenu_delete(Convert.ToInt32(ID["ID_Menu"]));
                    DataProcedure.spIngridient_delete(Convert.ToInt32(ID["ID_Ingridientov"]));
                    dgFill(QR);
                    cbFill();
                    cbFill2();
                    tbNameBluda.Text = "";
                    tbTime.Text = "";
                    tbCena.Text = "";
                    break;
                case MessageBoxResult.No:
                    switch (MessageBox.Show("Удалить продукт?", "Удаление!", MessageBoxButton.OKCancel, MessageBoxImage.Question))
                    {
                        case MessageBoxResult.OK:
                            DataProcedure.spIngridient_delete(Convert.ToInt32(ID["ID_Ingridientov"]));
                            dgFill(QR);
                            cbFill();
                            cbFill2();
                            tbNameBluda.Text = "";
                            tbTime.Text = "";
                            tbCena.Text = "";
                            break;
                    }
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
            tbNameBluda.Background = azaz6;
            tbTime.Background = azaz6;
            tbCena.Background = azaz6;

            tbSearch.Foreground = blackz;
            tbNameBluda.Foreground = blackz;
            tbTime.Foreground = blackz;
            tbCena.Foreground = blackz;
        }

        private void RadioButton_Checked_6(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz7 = (Brush)converter.ConvertFromString("#00000000");
            var whitez = (Brush)converter.ConvertFromString("#FFFFFF");
            tbSearch.Background = azaz7;
            tbNameBluda.Background = azaz7;
            tbTime.Background = azaz7;
            tbCena.Background = azaz7;

            tbSearch.Foreground = whitez;
            tbNameBluda.Foreground = whitez;
            tbTime.Foreground = whitez;
            tbCena.Foreground = whitez;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Navigation navigation = new Navigation();
            navigation.Show();
            Close();
        }

    }
}
