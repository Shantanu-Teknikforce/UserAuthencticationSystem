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

namespace UserAuthencticationSystem
{
   
    public partial class SuccessPage : Window
    {
        MainWindow m1;
      // public string url;
        public SuccessPage(MainWindow mainwindow)
        {
            InitializeComponent();
            this.m1 = mainwindow;

            label1.Content += m1.Username.Text;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m2 = new MainWindow();
            m2.Show();
            this.Close();
        }

        private void playvideo_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("https://www.google.com");
            webview.Navigate(uri);
        }
    }
}
