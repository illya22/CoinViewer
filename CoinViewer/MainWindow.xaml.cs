using CoinViewer.Helper;
using CoinViewer.Models;
using CoinViewer.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoinViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Page1_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Page1();
        }

        private async void Page2_Click(object sender, RoutedEventArgs e)
        {
            CoinAPI coinAPI = new CoinAPI();
            List<Currency> allCurrencies = await coinAPI.GetAllCurrencies();
            MyFrame.Content = new Page2(allCurrencies);
        }
    }
}
