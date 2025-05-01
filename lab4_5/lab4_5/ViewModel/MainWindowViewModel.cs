using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.ComponentModel;
using System;
using System.Globalization;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Controls;

namespace lab4_5
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _Products;

        public ObservableCollection<Product> Products { get => _Products;
            set { _Products = value; OnPropertyChanged(); } }

        public ObservableCollection<Product> tmpProducts { get; set; }
        public ObservableCollection<Product> tmpSearchProducts { get; set; }


        public User CurrentUser;
        public bool IsAdmin => CurrentUser?.Role == "Admin";
        public Product productToRemove { get; set; }

        private string _FromPrice;
        private string _ToPrice;
        public int _SelectedBrandIndex;
        public string FromPrice { get => _FromPrice; set { _FromPrice = value; OnPropertyChanged(); } }
        public string ToPrice { get => _ToPrice; set { _ToPrice = value; OnPropertyChanged(); } }
        public string Brand { get; set; }
        public int SelectedBrandIndex { get => _SelectedBrandIndex; set { _SelectedBrandIndex = value; OnPropertyChanged(); } }

        private string searchBox;
        public string SearchBox
        {
            get => searchBox;
            set { searchBox = value; OnPropertyChanged(); SearchProduct(); }
        }

        public ICommand OpenProfileCommand { get; }
        public ICommand ChangeThemeCommand { get; }
        public ICommand AddProductCommand { get; }
        public ICommand AdjustCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand ChangeLanguageCommand {  get; }
        public ICommand SearchCommand { get; }
        public ICommand RemoveProductCommand => new RelayCommand<Product>(DelProduct);

        public MainWindowViewModel() { }
        public MainWindowViewModel(User user)
        {
            CurrentUser = user;

            OpenProfileCommand = new RelayCommand(OpenProfile);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            AddProductCommand = new RelayCommand(AddProduct);
            AdjustCommand = new RelayCommand(Adjust);
            ClearCommand = new RelayCommand(Clear);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            SearchCommand = new RelayCommand(Search);

            Products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(File.ReadAllText("D:\\лабораторные работы\\ооп\\lab4_5\\pics\\products.json"));
            tmpProducts = Products;
        }

        private void OpenProfile()
        {
            MessageBox.Show("Профиль открыт");
            var settingsWindow = new SettingsWindow(CurrentUser);
            settingsWindow.Owner = Application.Current.MainWindow;
            settingsWindow.Show();
        }


        private int _currentThemeIndex = 0;
        private readonly string[] _themes =
        {
            "D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Themes\\DefaultTheme.xaml", // Тема по умолчанию
            "D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Themes\\DarkTheme.xaml",     // Темная тема
            "D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Themes\\BrownTheme.xaml"   // Дополнительная тема
        };

        private void ChangeTheme()
        {
            string themePath = _themes[_currentThemeIndex];

            var themeDict = new ResourceDictionary()
            {
                Source = new Uri(themePath, UriKind.Absolute)
            };

            var currentheme = Application.Current.Resources.MergedDictionaries
                              .FirstOrDefault(d => d.Source != null && d.Source.ToString().Contains("Themes"));

            if (currentheme != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(currentheme);
            }

            Application.Current.Resources.MergedDictionaries.Add(themeDict);

            _currentThemeIndex = (_currentThemeIndex + 1) % _themes.Length;
        }

        private void Adjust()
        {
            SortProduct();
        }
        
        public void SortProduct()
        {
            int priceFrom = int.TryParse(FromPrice, out int result) ? result : 0;
            int priceTo = int.TryParse(ToPrice, out int result1) ? result1 : 9999;
            string BrandSort = Brand;


            var sorted = tmpProducts
                .Where(p => (string.IsNullOrEmpty(BrandSort) || BrandSort == "Все" || p.Brand == BrandSort) &&
                    p.Price >= priceFrom && p.Price <= priceTo)
                .ToList();
            Products = new ObservableCollection<Product>(sorted);
            tmpSearchProducts = new ObservableCollection<Product>(sorted);
        }

        public void AddProduct()
        {
            AddProductWindow window1 = new AddProductWindow();
            window1.ShowDialog();
            var newProd = (window1.DataContext as AddProductViewModel).newProductReturned;
            tmpProducts.Add(newProd);
            string jsonPath = "D:\\лабораторные работы\\ооп\\lab4_5\\pics\\products.json";
            string updatedJson = JsonConvert.SerializeObject(tmpProducts, Formatting.Indented);
            File.WriteAllText(jsonPath, updatedJson);
        }

        private void Clear()
        {
            Products = tmpProducts;
            FromPrice = string.Empty;
            ToPrice = string.Empty;
            SelectedBrandIndex = 0;
        }

        public void SearchProduct()
        {
            string searchCriteria = SearchBox;

            if (tmpSearchProducts.Count > 0)
            {
                var searchLower = searchCriteria.ToLower();
                var filtered = tmpSearchProducts
                //.Where(p => p.Name.ToLower().Contains(searchLower));
                .Where(s => string.IsNullOrEmpty(searchCriteria) || s.Name.ToLower().Contains(searchCriteria?.ToLower() ?? ""));
                Products = new ObservableCollection<Product>(filtered);
            }

            else
            {
                var searchLower = searchCriteria.ToLower();
                var filtered = tmpProducts
                //.Where(p => p.Name.ToLower().Contains(searchLower));
                .Where(s => string.IsNullOrEmpty(searchCriteria) || s.Name.ToLower().Contains(searchCriteria?.ToLower() ?? ""));
                Products = new ObservableCollection<Product>(filtered);
            }
        }

        public void Search()
        {
            SearchProduct();
        }

        private string currentLanguage = "ru";
        private void ChangeLanguage()
        {
            string newLang = currentLanguage == "ru" ? "eng" : "ru";
            string newDictPath = $"D:\\лабораторные работы\\ооп\\lab4_5\\Resources\\Resources.{newLang}.xaml";



            var newDict = new ResourceDictionary
            {
                Source = new Uri(newDictPath, UriKind.Absolute)
            };

            var currentLang = Application.Current.Resources.MergedDictionaries
      .FirstOrDefault(d => d.Source != null && d.Source.ToString().Contains("Resources"));

            if (currentLang != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(currentLang);
            }

            Application.Current.Resources.MergedDictionaries.Add(newDict);

            currentLanguage = newLang;
        }

        public void DelProduct(Product productToRemove)
        {
            if (productToRemove != null)
            {
                var result = MessageBox.Show("Вы точно хотите удалить этот товар?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    string jsonPath = "D:\\лабораторные работы\\ооп\\lab4_5\\pics\\products.json";

                    try
                    {                  
                        var productToRemoveFromJson = tmpProducts.FirstOrDefault(p => p.Name == productToRemove.Name && p.Brand == productToRemove.Brand);
                        if (productToRemoveFromJson != null)
                        {
                            tmpProducts.Remove(productToRemoveFromJson);
                            Products.Remove(productToRemoveFromJson);
                        }

                        string updatedJson = JsonConvert.SerializeObject(tmpProducts, Formatting.Indented);
                        File.WriteAllText(jsonPath, updatedJson);

                        MessageBox.Show("Товар удален!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении товара из JSON: {ex.Message}");
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool b && b ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
//    public class MainWindowViewModel : INotifyPropertyChanged
//    {
//        private ObservableCollection<Product> _products;
//        public ObservableCollection<Product> Products
//        {
//            get { return _products; }
//            set
//            {
//                _products = value;
//                OnPropertyChanged(nameof(Products));
//                FilterProducts(); // Пока оставим, может пригодится
//            }
//        }

//        private ObservableCollection<Product> _filteredProducts;
//        public ObservableCollection<Product> FilteredProducts
//        {
//            get { return _filteredProducts; }
//            set
//            {
//                _filteredProducts = value;
//                OnPropertyChanged(nameof(FilteredProducts));
//            }
//        }

//        private User _currentUser;
//        public User CurrentUser
//        {
//            get { return _currentUser; }
//            set
//            {
//                _currentUser = value;
//                OnPropertyChanged(nameof(CurrentUser));
//            }
//        }

//        private string _searchText;
//        public string SearchText
//        {
//            get { return _searchText; }
//            set
//            {
//                _searchText = value;
//                OnPropertyChanged(nameof(SearchText));
//                // FilterProducts(); // Возможно, фильтрацию по поиску оставим в ViewModel
//            }
//        }

//        public int PriceFrom { get; set; }
//        public int PriceTo { get; set; } = 9999;
//        public string SelectedBrand { get; set; } = "Все";

//        private string _currentLanguage = Thread.CurrentThread.CurrentUICulture.Name.StartsWith("ru") ? "ru" : "eng";
//        public string CurrentLanguage
//        {
//            get { return _currentLanguage; }
//            set
//            {
//                if (_currentLanguage != value)
//                {
//                    _currentLanguage = value;
//                    OnPropertyChanged(nameof(CurrentLanguage));
//                    ChangeLanguage(value);
//                }
//            }
//        }

//        public ICommand DeleteCommand { get; }
//        public ICommand ChangeLanguageCommand { get; }
//        public ICommand AddProductCommand { get; }

//        private readonly string _jsonPath = "D:\\лабораторные работы\\ооп\\lab4_5\\pics\\products.json";
//        private readonly MainWindow _mainWindow;

//        public MainWindowViewModel(User user, MainWindow mainWindow)
//        {
//            _mainWindow = mainWindow;
//            CurrentUser = user;
//            LoadProducts();
//            FilteredProducts = new ObservableCollection<Product>(Products);
//            Brands = new ObservableCollection<string>(Products.Select(p => p.Brand).Distinct().OrderBy(b => b).Prepend("Все"));

//            DeleteCommand = new DeleteProductCommand(this);
//            ChangeLanguageCommand = new RelayCommand((_) => ToggleLanguage());
//            AddProductCommand = new RelayCommand((_) => OpenAddProductWindow());
//        }

//        public ObservableCollection<string> Brands { get; private set; }

//        private void LoadProducts()
//        {
//            if (File.Exists(_jsonPath))
//            {
//                var json = File.ReadAllText(_jsonPath);
//                Products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(json) ?? new ObservableCollection<Product>();
//            }
//            else
//            {
//                Products = new ObservableCollection<Product>();
//            }
//        }

//        public void SaveProducts()
//        {
//            var json = JsonConvert.SerializeObject(Products, Formatting.Indented);
//            File.WriteAllText(_jsonPath, json);
//        }

//        public void AddProduct(Product newProduct)
//        {
//            Products.Add(newProduct);
//            SaveProducts();
//            FilterProducts(); // Пока оставим
//        }

//        public void DeleteProduct(Product product)
//        {
//            if (MessageBox.Show("Вы точно хотите удалить этот товар?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
//            {
//                Products.Remove(product);
//                SaveProducts();
//                FilterProducts(); // Пока оставим
//                MessageBox.Show("Товар удален!");
//            }
//        }

//        private void FilterProducts()
//        {
//            FilteredProducts = new ObservableCollection<Product>(Products
//                .Where(p => (string.IsNullOrEmpty(SelectedBrand) || SelectedBrand == "Все" || p.Brand == SelectedBrand) &&
//                            p.Price >= PriceFrom && p.Price <= PriceTo &&
//                            (string.IsNullOrEmpty(SearchText) || p.Name.ToLower().Contains(SearchText.ToLower())))
//                .ToList());
//        }

//        private void ToggleLanguage()
//        {
//            CurrentLanguage = CurrentLanguage == "ru" ? "eng" : "ru";
//        }

//        private void ChangeLanguage(string newLang)
//        {
//            string newDictPath = $"D:\\лабораторные работы\\ооп\\lab4_5\\Resources\\Resources.{newLang}.xaml";

//            var dicts = Application.Current.Resources.MergedDictionaries;
//            dicts.Clear();

//            var newDict = new ResourceDictionary
//            {
//                Source = new Uri(newDictPath, UriKind.Absolute)
//            };
//            dicts.Add(newDict);
//        }

//        private void OpenAddProductWindow()
//        {
//            var addProductWindow = new Window1(_mainWindow);
//            addProductWindow.DataContext = new AddProductViewModel(this) { CloseWindow = () => addProductWindow.Close() };
//            addProductWindow.Owner = _mainWindow;
//            addProductWindow.ShowDialog();
//        }

//        public event PropertyChangedEventHandler PropertyChanged;

//        protected virtual void OnPropertyChanged(string propertyName)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }
//    }

//    public class DeleteProductCommand : ICommand
//    {
//        private readonly MainWindowViewModel _viewModel;

//        public DeleteProductCommand(MainWindowViewModel viewModel)
//        {
//            _viewModel = viewModel;
//        }

//        public event EventHandler CanExecuteChanged;

//        public bool CanExecute(object parameter)
//        {
//            return parameter is Product;
//        }

//        public void Execute(object parameter)
//        {
//            if (parameter is Product productToDelete)
//            {
//                _viewModel.DeleteProduct(productToDelete);
//            }
//        }
//    }
//}