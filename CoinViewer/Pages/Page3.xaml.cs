using CoinViewer.Models;
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
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        private Currency selectedCurrency;
        public Page3(Currency currency)
        {
            InitializeComponent();
            selectedCurrency = currency;

            // Ваша логіка для відображення деталей про валюту
            TextBlock currencyDetailsTextBlock = new TextBlock();
            currencyDetailsTextBlock.Text = $"Name: {selectedCurrency.Name}\nCode: {selectedCurrency.Symbol}\n" +
                                            $"Rank: {selectedCurrency.Rank} + " +
                                            $"\nSupply: {selectedCurrency.Supply}\n" +
                                            $"\nMarket Cap: {selectedCurrency.MarketCapUsd}\n" +
                                            $"Volume (24H): {selectedCurrency.VolumeUsd24Hr}\nPrice (USD): {selectedCurrency.Price}\n" +
                                            $"Change (24H): {selectedCurrency.ChangePercent24Hr}%\nVWAP (24H): {selectedCurrency.Vwap24Hr}";

            Content = currencyDetailsTextBlock;

        }
    }
}
