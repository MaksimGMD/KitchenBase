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
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        public Orders()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            var azaz7 = (Brush)converter.ConvertFromString("#00000000");
            btZakaz.Background = azaz7;
            btZakaz2.Background = azaz7;
            tbnz.Background = azaz7;
            tbvz.Background = azaz7;
            tbnz1.Background = azaz7;
            tbvz1.Background = azaz7;
            tbnz.BorderBrush = azaz7;
            tbvz.BorderBrush = azaz7;
            tbnz1.BorderBrush = azaz7;
            tbvz1.BorderBrush = azaz7;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Navigation Navigation = new Navigation();
            Navigation.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
