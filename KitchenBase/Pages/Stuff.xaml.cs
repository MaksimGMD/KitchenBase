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

namespace KitchenBase.Pages
{
    /// <summary>
    /// Логика взаимодействия для Stuff.xaml
    /// </summary>
    public partial class Stuff : Window
    {
        private string QR = "";
        DataProcedure DataProcedure = new DataProcedure();

        public Stuff()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrPersonal;
            dgFill(QR);
            CbPositionFill();

        }

        private void CbPositionFill()
        {
            DBConnection connection = new DBConnection();
            connection.DoljnostFill();
            CbPosition.ItemsSource = connection.dtDoljnost.DefaultView;
            CbPosition.SelectedValuePath = "ID_Doljnosti";
            CbPosition.DisplayMemberPath = "Должность";
        }

        private void dgFill(string qr)
        {
            DBConnection connection = new DBConnection();
            DBConnection.qrPersonal = qr;
            connection.PersonalFill();
            dgPersonal.ItemsSource = connection.dtPersonal.DefaultView;
            dgPersonal.Columns[0].Visibility = Visibility.Collapsed;
            dgPersonal.Columns[6].Visibility = Visibility.Collapsed;
            dgPersonal.Columns[8].Visibility = Visibility.Collapsed;
            dgPersonal.Columns[10].Visibility = Visibility.Collapsed;
        }

        private void DgPersonal_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Surname"):
                    e.Column.Header = "Фамилия";
                    break;
                case ("Name"):
                    e.Column.Header = "Имя";
                    break;
                case ("MiddleName"):
                    e.Column.Header = "Отчество";
                    break;
                case ("Email"):
                    e.Column.Header = "Почта";
                    break;
                case ("PhoneNumber"):
                    e.Column.Header = "НомерТелефона";
                    break;
                case ("Doljnost"):
                    e.Column.Header = "Должность";
                    break;
                case ("Login"):
                    e.Column.Header = "Логин";
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

        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz1 = (Brush)converter.ConvertFromString("#191970");
            Background = azaz1;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz2 = (Brush)converter.ConvertFromString("#696969");
            Background = azaz2;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
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

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
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

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
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
            tbSurname.Background = azaz6;
            tbName.Background = azaz6;
            tbMiddleName.Background = azaz6;
            tbEmail.Background = azaz6;
            tbPhoneNumber.Background = azaz6;
            tbLogin.Background = azaz6;
            tbPassword.Background = azaz6;
            tbPasswordConfirm.Background = azaz6;

            tbSearch.Foreground = blackz;
            tbSurname.Foreground = blackz;
            tbName.Foreground = blackz;
            tbMiddleName.Foreground = blackz;
            tbEmail.Foreground = blackz;
            tbPhoneNumber.Foreground = blackz;
            tbLogin.Foreground = blackz;
            tbPassword.Foreground = blackz;
            tbPasswordConfirm.Foreground = blackz;
        }

        private void RadioButton_Checked_6(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz7 = (Brush)converter.ConvertFromString("#00000000");
            var whitez = (Brush)converter.ConvertFromString("#FFFFFF");
            tbSearch.Background = azaz7;
            tbSurname.Background = azaz7;
            tbName.Background = azaz7;
            tbMiddleName.Background = azaz7;
            tbEmail.Background = azaz7;
            tbPhoneNumber.Background = azaz7;
            tbLogin.Background = azaz7;
            tbPassword.Background = azaz7;
            tbPasswordConfirm.Background = azaz7;

            tbSearch.Foreground = whitez;
            tbSurname.Foreground = whitez;
            tbName.Foreground = whitez;
            tbMiddleName.Foreground = whitez;
            tbEmail.Foreground = whitez;
            tbPhoneNumber.Foreground = whitez;
            tbLogin.Foreground = whitez;
            tbPassword.Foreground = whitez;
            tbPasswordConfirm.Foreground = whitez;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Navigation Navigation = new Navigation();
            Navigation.Show();
            Close();
        }

        public void Message()
        {
            MessageBox.Show("Поле не может быть пустым!! " +
             "\n Заполните все поля и попробуйте снова!", "KitchenBase",
             MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            switch (tbSurname.Text == "")
            {
                case (true):
                    Message();
                    tbSurname.Background = Brushes.Red;
                    break;
                case (false):
                    tbSurname.Background = Brushes.White;

                    switch (tbName.Text == "")
                    {
                        case (true):
                            Message();
                            tbName.Background = Brushes.Red;
                            break;
                        case (false):
                            tbName.Background = Brushes.White;

                                    switch (tbEmail.Text == "")
                                    {
                                        case (true):
                                            Message();
                                            tbEmail.Background = Brushes.Red;
                                            break;
                                        case (false):
                                            tbEmail.Background = Brushes.White;

                                            switch (tbPhoneNumber.Text == "")
                                            {
                                                case (true):
                                                    Message();
                                                    tbPhoneNumber.Background = Brushes.Red;
                                                    break;
                                                case (false):
                                                    tbPhoneNumber.Background = Brushes.White;

                                                    switch (CbPosition.SelectedIndex == -1)
                                                    {
                                                        case (true):
                                                            Message();
                                                            CbPosition.Background = Brushes.Red;
                                                            break;
                                                        case (false):
                                                            CbPosition.Background = Brushes.White;

                                                            switch (tbLogin.Text == "")
                                                            {
                                                                case (true):
                                                                    Message();
                                                                    tbLogin.Background = Brushes.Red;
                                                                    break;
                                                                case (false):
                                                                    tbLogin.Background = Brushes.White;

                                                                    switch (tbPassword.Text == "")
                                                                    {
                                                                        case (true):
                                                                            Message();
                                                                            tbPassword.Background = Brushes.Red;
                                                                            break;
                                                                        case (false):
                                                                            tbPassword.Background = Brushes.White;

                                                                            switch (tbPasswordConfirm.Text != tbPassword.Text)
                                                                            {
                                                                                case (true):
                                                                                    MessageBox.Show("Пароли не совпадают", "KitchenBase",
                                                                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                                                                                    tbPasswordConfirm.Background = Brushes.Red;
                                                                                    tbPassword.Background = Brushes.Red;
                                                                                    tbPasswordConfirm.Text = "";
                                                                                    tbPassword.Text = "";
                                                                                    break;
                                                                                case (false):
                                                                                    tbPasswordConfirm.Background = Brushes.White;
                                                                                    tbPassword.Background = Brushes.White;
                                                                                    DataProcedure.PresonalAdd(tbLogin.Text.ToString(), tbPassword.Text.ToString(), tbSurname.Text.ToString(), tbName.Text.ToString(), tbMiddleName.Text.ToString(),
                                                                                        tbEmail.Text.ToString(), tbPhoneNumber.Text.ToString(), Convert.ToInt32(CbPosition.SelectedValue.ToString()));
                                                                                    dgFill(QR);
                                                                                    CbPositionFill();
                                                                                    tbSurname.Text = "";
                                                                                    tbName.Text = "";
                                                                                    tbMiddleName.Text = "";
                                                                                    tbEmail.Text = "";
                                                                                    tbPhoneNumber.Text = "";
                                                                                    tbLogin.Text = "";
                                                                                    tbPassword.Text = "";
                                                                                    tbPasswordConfirm.Text = "";
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
                                            break;
                                    }
                                    break;
                            }
                            break;                 
            }
        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            switch (tbSurname.Text == "")
            {
                case (true):
                    Message();
                    tbSurname.Background = Brushes.Red;
                    break;
                case (false):
                    tbSurname.Background = Brushes.White;

                    switch (tbName.Text == "")
                    {
                        case (true):
                            Message();
                            tbName.Background = Brushes.Red;
                            break;
                        case (false):
                            tbName.Background = Brushes.White;                        

                                    switch (tbEmail.Text == "")
                                    {
                                        case (true):
                                            Message();
                                            tbEmail.Background = Brushes.Red;
                                            break;
                                        case (false):
                                            tbEmail.Background = Brushes.White;

                                            switch (tbPhoneNumber.Text == "")
                                            {
                                                case (true):
                                                    Message();
                                                    tbPhoneNumber.Background = Brushes.Red;
                                                    break;
                                                case (false):
                                                    tbPhoneNumber.Background = Brushes.White;

                                                    switch (CbPosition.SelectedIndex == -1)
                                                    {
                                                        case (true):
                                                            Message();
                                                            CbPosition.Background = Brushes.Red;
                                                            break;
                                                        case (false):
                                                            CbPosition.Background = Brushes.White;

                                                            switch (tbLogin.Text == "")
                                                            {
                                                                case (true):
                                                                    Message();
                                                                    tbLogin.Background = Brushes.Red;
                                                                    break;
                                                                case (false):
                                                                    tbLogin.Background = Brushes.White;

                                                                    switch (tbPassword.Text == "")
                                                                    {
                                                                        case (true):
                                                                            Message();
                                                                            tbPassword.Background = Brushes.Red;
                                                                            break;
                                                                        case (false):
                                                                            tbPassword.Background = Brushes.White;

                                                                            switch (tbPasswordConfirm.Text != tbPassword.Text)
                                                                            {
                                                                                case (true):
                                                                                    MessageBox.Show("Пароли не совпадают", "KitchenBase",
                                                                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                                                                                    tbPasswordConfirm.Background = Brushes.Red;
                                                                                    tbPassword.Background = Brushes.Red;
                                                                                    tbPasswordConfirm.Text = "";
                                                                                    tbPassword.Text = "";
                                                                                    break;
                                                                                case (false):
                                                                                    tbPasswordConfirm.Background = Brushes.White;
                                                                                    tbPassword.Background = Brushes.White;
                                                                                    DataRowView ID = (DataRowView)dgPersonal.SelectedItems[0];
                                                                                    DataProcedure.PresonalUpdate(Convert.ToInt32(ID["ID_Personala"]), tbLogin.Text.ToString(), tbPassword.Text.ToString(), tbName.Text.ToString(), tbSurname.Text.ToString(), tbMiddleName.Text.ToString(),
                                                                                        tbEmail.Text.ToString(), tbPhoneNumber.Text.ToString(), Convert.ToInt32(CbPosition.SelectedValue.ToString()));
                                                                                    dgFill(QR);
                                                                                    CbPositionFill();
                                                                                    tbSurname.Text = "";
                                                                                    tbName.Text = "";
                                                                                    tbMiddleName.Text = "";
                                                                                    tbEmail.Text = "";
                                                                                    tbPhoneNumber.Text = "";
                                                                                    tbLogin.Text = "";
                                                                                    tbPassword.Text = "";
                                                                                    tbPasswordConfirm.Text = "";
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
                                            break;
                                    }
                                    break;
                            }
                            break;
            }
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgPersonal.SelectedItems[0];
            switch (MessageBox.Show("Хотите удалить запись?", "Удаление!", MessageBoxButton.OKCancel, MessageBoxImage.Question))
            {
                case MessageBoxResult.OK:
                    DataProcedure procedure = new DataProcedure();
                    procedure.spPersonal_delete(Convert.ToInt32(ID["ID_Personala"]));
                    procedure.spAuthorization_delete(Convert.ToInt32(ID["ID_Authorization"]));
                    dgFill(QR);
                    CbPositionFill();
                    tbSurname.Text = "";
                    tbName.Text = "";
                    tbMiddleName.Text = "";
                    tbEmail.Text = "";
                    tbPhoneNumber.Text = "";
                    tbLogin.Text = "";
                    tbPassword.Text = "";
                    tbPasswordConfirm.Text = "";
                    break;
            }
        }
        //Поиск
        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgPersonal.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[5].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[7].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[9].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[10].ToString() == tbSearch.Text)
                {
                    dgPersonal.SelectedItem = dataRow;
                }
            }
        }
        //Фильтрация данных в таблице
        private void BtFilter_Click(object sender, RoutedEventArgs e)
        {
            if (tbSearch.Text != "")
            {
                string newQR = QR + " where [Surname] like '%" + tbSearch.Text + "%' or [Name] like '%" + tbSearch.Text + "%' or [MiddleName] like '%" + tbSearch.Text + "%' or " +
                    "[Email] like '%" + tbSearch.Text + "%' or [PhoneNumber] like '%" + tbSearch.Text + "%' or [Doljnost] like '%" + tbSearch.Text + "%'" +
                    "or [Login] like '%" + tbSearch.Text + "%' or [Password] like '%" + tbSearch.Text + "%'";
                dgFill(newQR);
            }
        }
        //Отмена поиска и фильтрации
        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = string.Empty;
            dgFill(QR);
        }

        //маска для номера телефона
        private void TbPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {           
            string a;
            a = tbPhoneNumber.Text;
            tbPhoneNumber.MaxLength = 12;
            if (a.Length == 1)
            {
                tbPhoneNumber.Text = "+7" + tbPhoneNumber.Text;//добавляет +7
                tbPhoneNumber.SelectionStart = tbPhoneNumber.Text.Length; //перенос в конец строки
            }
        }
        //всплывающее оповещение
        private void TbPhoneNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Начинайте вводить номер телефона без +7 ", "KitchenBase", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void TbLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Минимальная длина логина составляет 8 символов ", "KitchenBase", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

    }
}
