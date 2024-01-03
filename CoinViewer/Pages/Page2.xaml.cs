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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private List<Currency> allCurrencies;
        private List<Currency> filteredCurrencies;
        private TextBox searchTextBox;
        private ListBox allCurrenciesListBox;

        public Page2(List<Currency> currencies)
        {
            InitializeComponent();
            allCurrencies = currencies;
            filteredCurrencies = new List<Currency>(allCurrencies);

            // Створення TextBox для пошуку
            searchTextBox = new TextBox();
            searchTextBox.TextChanged += SearchTextBox_TextChanged;

            // Створення ListBox для відображення валют
            allCurrenciesListBox = new ListBox();
            allCurrenciesListBox.ItemsSource = filteredCurrencies;
            allCurrenciesListBox.SelectionChanged += AllCurrenciesListBox_SelectionChanged;



            // Створення StackPanel для організації відображення
            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(searchTextBox);
            stackPanel.Children.Add(allCurrenciesListBox); // Додано ScrollViewer замість прямого додавання ListBox

            // Встановлення StackPanel як вміст сторінки
            Content = stackPanel;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Фільтрація валют на основі введеного тексту пошуку
            string searchText = searchTextBox.Text.ToLower();
            filteredCurrencies = allCurrencies.Where(currency => currency.Name.ToLower().Contains(searchText) || currency.Symbol.ToLower().Contains(searchText)).ToList();

            // Оновлення джерела даних ListBox
            allCurrenciesListBox.ItemsSource = filteredCurrencies;
        }

        private void AllCurrenciesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обробник вибору валюти
            if (allCurrenciesListBox.SelectedItem != null)
            {
                Currency selectedCurrency = (Currency)allCurrenciesListBox.SelectedItem;
                NavigationService.Navigate(new Page3(selectedCurrency));
            }
        }
    }
}

