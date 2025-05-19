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
using System.Windows.Threading;
using System.Data.SqlClient;

namespace lab4_5
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _Products;
        public ObservableCollection<Product> Products { get => _Products;
            set { _Products = value; OnPropertyChanged(); } }

        public ObservableCollection<Product> tmpProducts { get; set; }
        public ObservableCollection<Product> tmpSearchProducts { get; set; }

        private ObservableCollection<Product> _Cart = new ObservableCollection<Product>();
        public ObservableCollection<Product> Cart
        {
            get => _Cart;
            set { _Cart = value; OnPropertyChanged(); }
        }


        public string ConnectionString = "Data source = WIN-0RRORC9T71J\\SQLEXPRESS; Initial Catalog = CosmeticShop;TrustServerCertificate=Yes;Integrated Security=True;";

        public User CurrentUser;
        public bool IsAdmin => CurrentUser?.Role == "Admin";
        public Product productToRemove { get; set; }
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged();

                    if (_selectedProduct != null)
                    {
                        ShowProductDetails(_selectedProduct);
                    }
                }
            }
        }

        private string _FromPrice;
        private string _ToPrice;
        public int _SelectedBrandIndex;
        public string FromPrice { get => _FromPrice; set { _FromPrice = value; OnPropertyChanged(); } }
        public string ToPrice { get => _ToPrice; set { _ToPrice = value; OnPropertyChanged(); } }
        public string Brand { get; set; }
        public int SelectedBrandIndex { get => _SelectedBrandIndex; set { _SelectedBrandIndex = value; OnPropertyChanged(); } }

        private string _searchBox;
        public string SearchBox
        {
            get => _searchBox;
            set
            {
                if (_searchBox != value)
                {
                    _searchBox = value;
                    OnPropertyChanged(nameof(SearchBox));

                    _searchDebounceTimer.Stop();
                    _searchDebounceTimer.Start();
                }
            }
        }

        private readonly DispatcherTimer _searchDebounceTimer;

        private Stack<ActionItem> _undoStack = new Stack<ActionItem>();
        private Stack<ActionItem> _redoStack = new Stack<ActionItem>();

        //private bool CanUndo() => _undoStack.Count > 0;
        //private bool CanRedo() => _redoStack.Count > 0;

        public ICommand AddToCartCommand { get; }
        //public ICommand UndoCommand => new RelayCommand(Undo, () => CanUndo());
        //public ICommand RedoCommand => new RelayCommand(Redo, () => CanRedo());
        public ICommand OpenProfileCommand { get; }
        public ICommand ChangeThemeCommand { get; }
        public ICommand AddProductCommand { get; }
        public ICommand ShowUsersCommand { get; }
        public ICommand AdjustCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand ChangeLanguageCommand {  get; }
        public ICommand SearchCommand { get; }
        public ICommand RemoveProductCommand => new RelayCommand<Product>(DelProduct);
        public ICommand ShowProductViewCommand { get; }
        public ICommand OpenEditWindowCommand { get; }

        public MainWindowViewModel() { }
        public MainWindowViewModel(User user)
        {
            CurrentUser = user;
            OpenProfileCommand = new RelayCommand(OpenProfile);
            OpenEditWindowCommand = new RelayCommand<Product>(OpenEditWindow);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            AddProductCommand = new RelayCommand(AddProduct);
            AdjustCommand = new RelayCommand(Adjust);
            ClearCommand = new RelayCommand(Clear);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            SearchCommand = new RelayCommand(Search);
            ShowUsersCommand = new RelayCommand(ShowUsers);
            ShowProductViewCommand = new RelayCommand<Product>(ShowProductDetails);
            AddToCartCommand = new RelayCommand<Product>(AddToCart);
            //Products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(File.ReadAllText("D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Resources\\products.json"));
            LoadProducts();
            tmpProducts = new ObservableCollection<Product>(Products);
            tmpSearchProducts = new ObservableCollection<Product>(Products);

            ApplyLocalizationToProducts();

            _searchDebounceTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(300)
            };
            _searchDebounceTimer.Tick += (s, e) =>
            {
                _searchDebounceTimer.Stop();
                SearchProduct();
            };
        }

        //public void Undo()
        //{
        //    if (_undoStack.Count > 0)
        //    {
        //        var action = _undoStack.Pop();

        //        switch (action.ActionType)
        //        {
        //            case "Add":
        //                Products.Remove(action.Product);
        //                _redoStack.Push(new ActionItem("Add", action.Product)); 
        //                break;

        //            case "Remove":
        //                Products.Add(action.Product);
        //                _redoStack.Push(new ActionItem("Remove", action.Product));
        //                break;
        //        }

        //        (UndoCommand as RelayCommand)?.RaiseCanExecuteChanged();
        //        (RedoCommand as RelayCommand)?.RaiseCanExecuteChanged();
        //    }
        //}

        //public void Redo()
        //{
        //    if (_redoStack.Count > 0)
        //    {
        //        var action = _redoStack.Pop();

        //        switch (action.ActionType)
        //        {
        //            case "Add":
        //                Products.Add(action.Product);
        //                tmpProducts.Add(action.Product);
        //                _undoStack.Push(new ActionItem("Add", action.Product));
        //                break;

        //            case "Remove":
        //                Products.Remove(action.Product);
        //                tmpProducts.Remove(action.Product);
        //                _undoStack.Push(new ActionItem("Remove", action.Product));
        //                break;
        //        }

        //        (UndoCommand as RelayCommand)?.RaiseCanExecuteChanged();
        //        (RedoCommand as RelayCommand)?.RaiseCanExecuteChanged();
        //    }
        //}

        private void LoadProducts()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
            SELECT g.*, b.BrandDescription 
            FROM Goods g
            JOIN Brands b ON g.BrandId = b.BrandId", connection);

                using (var reader = command.ExecuteReader())
                {
                    var _goods = new ObservableCollection<Product>();

                    while (reader.Read())
                    {
                        var product = new Product
                        (
                            id: reader.GetInt32(reader.GetOrdinal("Id")),
                            name: reader["Name"].ToString(),
                            description: reader["Description"].ToString(),
                            brand: reader["Brand"].ToString(),
                            imagePath: reader["ImagePath"].ToString(),
                            buy: reader["Buy"].ToString(),
                            delete: reader["DeleteCommand"].ToString(),
                            price: reader.GetDouble(reader.GetOrdinal("Price")),
                            composition: reader.IsDBNull(reader.GetOrdinal("Composition")) ? "" : reader.GetString(reader.GetOrdinal("Composition"))
                        );

                        product.BrandDescription = reader.IsDBNull(reader.GetOrdinal("BrandDescription")) ? "" : reader["BrandDescription"].ToString();

                        _goods.Add(product);
                    }

                    Products = _goods;
                }
            }
        }

        public class ActionItem
        {
            public string ActionType { get; set; }
            public Product Product { get; set; }

            public ActionItem(string actionType, Product product)
            {
                ActionType = actionType;
                Product = product;
            }
        }
        public void OpenEditWindow(Product selectedProduct)
        {
            if (selectedProduct == null) return;

            EditProductWindow epw = new EditProductWindow(selectedProduct);
            epw.ShowDialog();

        }
        public void AddToCart(Product productToAdd)
        {
            if (productToAdd == null)
                return;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int cartId;

                        using (SqlCommand getCartCmd = new SqlCommand("SELECT CartId FROM Carts WHERE UserId = @UserId", conn, transaction))
                        {
                            getCartCmd.Parameters.AddWithValue("@UserId", CurrentUser.Id);
                            var result = getCartCmd.ExecuteScalar();

                            if (result != null)
                                cartId = Convert.ToInt32(result);
                            else
                            {
                                using (SqlCommand createCartCmd = new SqlCommand("INSERT INTO Carts (UserId) OUTPUT INSERTED.CartId VALUES (@UserId)", conn, transaction))
                                {
                                    createCartCmd.Parameters.AddWithValue("@UserId", CurrentUser.Id);
                                    cartId = (int)createCartCmd.ExecuteScalar();
                                }
                            }
                        }

                        int productId;
                        using (SqlCommand getProductCmd = new SqlCommand("SELECT Id FROM Goods WHERE Name = @Name AND Brand = @Brand", conn, transaction))
                        {
                            getProductCmd.Parameters.AddWithValue("@Name", productToAdd.Name);
                            getProductCmd.Parameters.AddWithValue("@Brand", productToAdd.Brand);
                            object productResult = getProductCmd.ExecuteScalar();

                            if (productResult == null)
                            {
                                MessageBox.Show("Товар не найден в базе данных.");
                                transaction.Rollback();
                                return;
                            }

                            productId = Convert.ToInt32(productResult);
                        }

                        int existingQuantity = 0;
                        using (SqlCommand checkItemCmd = new SqlCommand("SELECT Quantity FROM CartItems WHERE CartId = @CartId AND ProductId = @ProductId", conn, transaction))
                        {
                            checkItemCmd.Parameters.AddWithValue("@CartId", cartId);
                            checkItemCmd.Parameters.AddWithValue("@ProductId", productId);

                            object quantityResult = checkItemCmd.ExecuteScalar();
                            if (quantityResult != null)
                            {
                                existingQuantity = Convert.ToInt32(quantityResult);
                            }
                        }

                        if (existingQuantity > 0)
                        {
                            using (SqlCommand updateQuantityCmd = new SqlCommand(
                                "UPDATE CartItems SET Quantity = Quantity + 1 WHERE CartId = @CartId AND ProductId = @ProductId", conn, transaction))
                            {
                                updateQuantityCmd.Parameters.AddWithValue("@CartId", cartId);
                                updateQuantityCmd.Parameters.AddWithValue("@ProductId", productId);
                                updateQuantityCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (SqlCommand insertItemCmd = new SqlCommand(
                                "INSERT INTO CartItems (CartId, ProductId, Quantity) VALUES (@CartId, @ProductId, 1)", conn, transaction))
                            {
                                insertItemCmd.Parameters.AddWithValue("@CartId", cartId);
                                insertItemCmd.Parameters.AddWithValue("@ProductId", productId);
                                insertItemCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Товар добавлен в корзину!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка при добавлении в корзину: {ex.Message}");
                    }
                }
            }
        }
        
        private void ShowProductDetails(Product selectedProduct)
        {
            if (selectedProduct == null) return;

            var detailsWindow = new ProductViewWindow(CurrentUser);
            var vm = new ProductViewViewModel(CurrentUser);
            vm.Product = selectedProduct;
            detailsWindow.DataContext = vm;
            detailsWindow.ShowDialog();
        }
        private void OpenProfile()
        { 
            var settingsWindow = new SettingsWindow(CurrentUser);
            settingsWindow.ShowDialog();
        }


        private int _currentThemeIndex = 0;
        private readonly string[] _themes =
        {
            "D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Themes\\DarkTheme.xaml",     // Темная тема
            //"D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Themes\\BrownTheme.xaml",
            "D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Themes\\DefaultTheme.xaml", // Тема по умолчанию
        };

        
        private void ApplyLocalizationToProducts()
        {
            string localizedBuy = (string)Application.Current.Resources["Buy"];
            string localizedDelete = (string)Application.Current.Resources["Delete"];
            foreach (var product in Products)
            {
                product.Buy = localizedBuy;
                product.Delete = localizedDelete;
            }
        }
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
        public void ShowUsers()
        {
            UsersWindow usersWindow = new UsersWindow(CurrentUser);
            usersWindow.ShowDialog();
        }
        public void AddProduct()
        {
            AddProductWindow window1 = new AddProductWindow();
            window1.ShowDialog();

            var newProd = (window1.DataContext as AddProductViewModel).newProductReturned;

            if (newProd != null)
            {
                tmpProducts.Add(newProd);
                _undoStack.Push(new ActionItem("Add", newProd));
                _redoStack.Clear();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Шаг 1: Получить или добавить бренд, получить его BrandId
                            int brandId;

                            using (var checkBrandCmd = new SqlCommand("SELECT BrandId FROM Brands WHERE BrandName = @BrandName", connection, transaction))
                            {
                                checkBrandCmd.Parameters.AddWithValue("@BrandName", newProd.Brand);
                                var result = checkBrandCmd.ExecuteScalar();

                                if (result != null)
                                {
                                    brandId = Convert.ToInt32(result);
                                }
                                else
                                {
                                    using (var insertBrandCmd = new SqlCommand("INSERT INTO Brands (BrandName) OUTPUT INSERTED.BrandId VALUES (@BrandName)", connection, transaction))
                                    {
                                        insertBrandCmd.Parameters.AddWithValue("@BrandName", newProd.Brand);
                                        brandId = (int)insertBrandCmd.ExecuteScalar();
                                    }
                                }
                            }

                            // Шаг 2: Вставка нового товара
                            var command = new SqlCommand(@"
                        INSERT INTO Goods 
                        (Name, Description, Brand, ImagePath, Buy, DeleteCommand, Price, BrandId, Composition) 
                        VALUES 
                        (@Name, @Description, @Brand, @ImagePath, @Buy, @DeleteCommand, @Price, @BrandId, @Composition)", connection, transaction);

                            command.Parameters.AddWithValue("@Name", newProd.Name);
                            command.Parameters.AddWithValue("@Description", newProd.Description);
                            command.Parameters.AddWithValue("@Brand", newProd.Brand);
                            command.Parameters.AddWithValue("@ImagePath", newProd.ImagePath);
                            command.Parameters.AddWithValue("@Buy", newProd.Buy);
                            command.Parameters.AddWithValue("@DeleteCommand", newProd.Delete);
                            command.Parameters.AddWithValue("@Price", newProd.Price);
                            command.Parameters.AddWithValue("@BrandId", brandId);
                            command.Parameters.AddWithValue("@Composition", newProd.Composition ?? (object)DBNull.Value);

                            command.ExecuteNonQuery();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}");
                        }
                    }
                }

                Products.Add(newProd);
                tmpProducts = new ObservableCollection<Product>(Products);
                tmpSearchProducts = new ObservableCollection<Product>(Products);
                ApplyLocalizationToProducts();
            }
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
            string newDictPath = $"D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Resources\\Resources.{newLang}.xaml";

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

            string localizedBuy = (string)Application.Current.Resources["Buy"];
            foreach (var product in Products)
            {
                product.Buy = localizedBuy; 
            }

            currentLanguage = newLang;
        }

        public void DelProduct(Product productToRemove)
        {
            if (productToRemove != null)
            {
                var result = MessageBox.Show("Вы точно хотите удалить этот товар?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();

                        using (SqlTransaction transaction = conn.BeginTransaction())
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Goods WHERE Name = @Name AND Brand = @Brand", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Name", productToRemove.Name);
                            cmd.Parameters.AddWithValue("@Brand", productToRemove.Brand);

                            try
                            {
                                int rowsAffected = cmd.ExecuteNonQuery();
                                transaction.Commit();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Товар удален из базы данных!");
                                    _undoStack.Push(new ActionItem("Remove", productToRemove));
                                    _redoStack.Clear();

                                    Products.Remove(productToRemove);
                                }
                                else
                                {
                                    MessageBox.Show("Товар не найден в базе данных!");
                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Ошибка при удалении из базы данных: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }


        //string jsonPath = "D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Resources\\products.json";

        //var productToRemoveFromJson = tmpProducts.FirstOrDefault(p => p.Name == productToRemove.Name && p.Brand == productToRemove.Brand);
        //if (productToRemoveFromJson != null)
        //{
        //    tmpProducts.Remove(productToRemoveFromJson);
        //    Products.Remove(productToRemoveFromJson);

        //    _undoStack.Push(new ActionItem("Remove", productToRemoveFromJson));
        //    _redoStack.Clear();

        //    string updatedJson = JsonConvert.SerializeObject(tmpProducts, Formatting.Indented);
        //    File.WriteAllText(jsonPath, updatedJson);

        //    MessageBox.Show("Товар удален!");
        //}
        //else
        //{
        //    MessageBox.Show("Товар не найден в списке!");
        //}
        //        }
        //    }
        //}


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
