using Newtonsoft.Json;
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
using System.IO;
using System.Collections;
using System.Reflection;

namespace lab4_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText("D:\\лабораторные работы\\ооп\\lab4_5\\pics\\products.json"));

        List<Product> sortedProducts = new List<Product>();

        List<Product> foundProducts = new List<Product>();

        public MainWindow()
        {
            InitializeComponent();
            //Cursor cursor = new Cursor("D:\\лабораторные работы\\ооп\\lab4_5\\pics\\klipartz.com.cur");
            //this.Cursor = cursor;
            LoadProducts(products);
        }
        public void LoadProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                var border = new Border
                {
                    CornerRadius = new CornerRadius(8),
                    Background = Brushes.White,
                    BorderBrush = Brushes.LightGray,
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(0, 5, 5, 0)
                };
                var stack = new StackPanel();

                var image = new Image
                {
                    Source = new BitmapImage(new Uri(product.ImagePath, UriKind.Absolute)),
                    Stretch = Stretch.Uniform,
                    Height = 100,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                var name = new TextBlock
                {
                    Text = product.Name,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(10, 5, 10, 0),
                    Height = 40,
                    TextAlignment = TextAlignment.Right,
                    TextWrapping = TextWrapping.Wrap
                };

                var description = new TextBlock
                {
                    Text = product.Description,
                    Foreground = Brushes.Gray,
                    Margin = new Thickness(10, 5, 10, 5),
                    TextAlignment = TextAlignment.Right
                };

                var button = new Button
                {
                    Content = "Купить",
                    Margin = new Thickness(5, 1, 5, 5),
                    Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#A578BB"),
                    Foreground = Brushes.White,
                    Height = 20,
                    BorderThickness = new Thickness(0)
                };

                var buttonDel = new Button
                {
                    Content = "Удалить",
                    Margin = new Thickness(5, 1, 5, 5),
                    Background = Brushes.Red,
                    Foreground = Brushes.White,
                    Height = 20,
                    BorderThickness = new Thickness(0),
                    Tag = product
                };
                buttonDel.Click += DelProduct_Click;

                stack.Children.Add(image);
                stack.Children.Add(description);
                stack.Children.Add(name);
                stack.Children.Add(button);
                stack.Children.Add(buttonDel);

                border.Child = stack;

                CatalogPanel.Children.Add(border);
            }
        }

        //фильтрация начинается тут!!!!!
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumeric(e.Text);
        }

        private void NumberOnly_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextNumeric(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private bool IsTextNumeric(string text)
        {
            return text.All(char.IsDigit);
        }
        private void Adjust_Click(object sender, RoutedEventArgs e)
        {
            var sorted = SortProduct();
            CatalogPanel.Children.Clear();
            LoadProducts(sortedProducts);
        }
        public List<Product> SortProduct()
        {
            sortedProducts.Clear();
            int priceFrom = int.TryParse(FromTB.Text, out int result) ? result : 0;
            int priceTo = int.TryParse(ToTB.Text, out int result1) ? result1 : 9999;
            string BrandSort = Brand.Text;

            var sorted = products
                .Where(p => (string.IsNullOrEmpty(BrandSort) || BrandSort == "Все" || p.Brand == BrandSort) &&
                    p.Price >= priceFrom && p.Price <= priceTo)
                .ToList();
            sortedProducts.AddRange(sorted);
            return sortedProducts;
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            var sorted = SortProduct();
            CatalogPanel.Children.Clear();

            FromTB.Clear();
            ToTB.Clear();

            if (Brand.Items.Count > 0)
            {
                Brand.SelectedIndex = 0;
            }

            LoadProducts(products);
        }

        //poisk pisek
        public List<Product> SearchProduct()
        {
            foundProducts.Clear();
            string searchCriteria = SearchBox.Text;

            if (string.IsNullOrEmpty(searchCriteria))
            {
                foundProducts.AddRange(products);
            }

            else
            {
                var searchLower = searchCriteria.ToLower();
                var filtered = products
                    .Where(p => p.Name.ToLower().Contains(searchLower))
                    .ToList();
                foundProducts.AddRange(filtered);
            }
            return foundProducts;
        }
        public void Search_Click(object sender, RoutedEventArgs e)
        {
            var results = SearchProduct();
            CatalogPanel.Children.Clear();
            LoadProducts(results);
        }

        public void SearchBox_TextChanged(object sender, RoutedEventArgs e)
        {
            var results = SearchProduct();
            CatalogPanel.Children.Clear();
            LoadProducts(results);
        }

        //lang
        private string currentLanguage = "ru";
        private void ChangeLanguage_Click(object sender, RoutedEventArgs e)
        {
            string newLang = currentLanguage == "ru" ? "eng" : "ru";
            string newDictPath = $"D:\\лабораторные работы\\ооп\\lab4_5\\Resources\\Resources.{newLang}.xaml";

            var dicts = Application.Current.Resources.MergedDictionaries;
            dicts.Clear();

            var newDict = new ResourceDictionary
            {
                Source = new Uri(newDictPath, UriKind.Absolute)
            };
            dicts.Add(newDict);

            currentLanguage = newLang;
        }

        //manage products
        public void DelProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var productToRemove = button?.Tag as Product;

            if (productToRemove != null)
            {
                var result = MessageBox.Show("Вы точно хотите удалить этот товар?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    products.Remove(productToRemove); 
                    CatalogPanel.Children.Clear();
                    LoadProducts(products);          
                }
            }
        }

        public void AddProduct_Click(object sender, RoutedEventArgs e)
        {

        }
        public void AddProduct(Product product)
        {

        }
    }
}
