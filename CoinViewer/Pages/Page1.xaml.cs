using CoinViewer.Helper;
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

namespace CoinViewer.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private async void Page_Load(object sender, RoutedEventArgs e)
        {
            CoinAPI coinCapApi = new CoinAPI();

            List<string> coinNames = await coinCapApi.GetAllCoinNames();

            if (coinNames != null)
            {

                textBox.Text = string.Join(Environment.NewLine, coinNames);
            }
        }
    }
}
