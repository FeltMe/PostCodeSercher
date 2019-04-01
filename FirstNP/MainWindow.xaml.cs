﻿using FirstNP.Client;
using FirstNP.Db;
using System;
using System.Windows;

namespace FirstNP
{
    /// <summary>
    /// Interactio/n logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MyAdresesSercherClient MyCliet { get; set; } = new MyAdresesSercherClient();
        public Adreses MyAdreses { get; set; } = new Adreses();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var Code = int.Parse(MyTextBox.Text);
                MyCliet.Start(Code);

            }
            catch (FormatException)
            {
                MessageBox.Show("FormatException");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("ArgumentException");
            }
        }
    }
}
