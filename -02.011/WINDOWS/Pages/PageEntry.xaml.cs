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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _02._011.WINDOWS.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEntry.xaml
    /// </summary>
    public partial class PageEntry : Page
    {
        public PageEntry()
        {
            InitializeComponent();
        }

        private void Button_MainMenu(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.СurrentFrame.Navigate(new PageMenu());
        }
    }
}
