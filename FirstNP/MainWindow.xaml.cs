using FirstNP.Client;
using FirstNP.Db;
using System;
using System.Collections.Generic;
using System.Windows;

namespace FirstNP
{
    /// <summary>
    /// Interactio/n logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MyAdresesSercherClient MyCliet { get; set; } = new MyAdresesSercherClient();
        public List<string> MyAdreses { get; set; } = new List<string>();

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
                MyAdreses = MyCliet.Start(MyTextBox.Text);
                Print(MyAdreses);

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
        private void Print(List<string> adreses)
        {
            foreach (var item in adreses)
            {
                MyListView.Items.Add("Lel");
            }
        }
    }
}
