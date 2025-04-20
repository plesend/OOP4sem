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

namespace lab4_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText("D:\\лабораторные работы\\ооп\\lab4_5\\pics\\products.json"));

        List<Product> sortedProducts = new List<Product>();

        public MainWindow()
        {
            InitializeComponent();
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

                stack.Children.Add(image);
                stack.Children.Add(description);
                stack.Children.Add(name);
                stack.Children.Add(button);

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
    }
}
