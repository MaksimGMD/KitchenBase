﻿using System;
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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        private string QR = "";
        //Определяет есть подключение к БД или нет
        public Authorization()
        {
            InitializeComponent();
        }

        private void btAccept_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
