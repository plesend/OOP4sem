using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace lab4_5
{
    class ProductViewViewModel : INotifyPropertyChanged
    {
        private Product _product;
        private User _currentUser; 
        private string _newReviewText;
        private int _newReviewRating = 5;
        public bool IsAdmin => _currentUser?.Role == "Admin";

        public ICommand SubmitReviewCommand { get; }
        public ICommand BuyCommand { get; }
        public ProductViewViewModel(User user)
        {
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
            SubmitReviewCommand = new RelayCommand(SubmitReview, CanSubmitReview);
            BuyCommand = new RelayCommand<Product>(AddToCart);
        }

        public Product Product
        {
            get => _product;
            set
            {
                if (_product != value)
                {
                    _product = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(Description));
                    OnPropertyChanged(nameof(Brand));
                    OnPropertyChanged(nameof(ImagePath));
                    OnPropertyChanged(nameof(Buy));
                    OnPropertyChanged(nameof(Delete));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Composition));

                    LoadReviewsFromDatabase();
                }
            }
        }

        public string connectionString = "Data source=WIN-0RRORC9T71J\\SQLEXPRESS;Initial Catalog=CosmeticShop;TrustServerCertificate=Yes;Integrated Security=True;";

        public string Name => Product?.Name;
        public string Description => Product?.Description;
        public string Brand => Product?.Brand;
        public string ImagePath => Product?.ImagePath;
        public string Buy => Product?.Buy;
        public string Delete => Product?.Delete;
        public double Price => Product?.Price ?? 0;
        public string Composition => Product?.Composition;

        public ObservableCollection<string> Reviews => Product?.Reviews;

        public string NewReviewText
        {
            get => _newReviewText;
            set
            {
                _newReviewText = value;
                OnPropertyChanged();
            }
        }

        public int NewReviewRating
        {
            get => _newReviewRating;
            set
            {
                _newReviewRating = value;
                OnPropertyChanged();
            }
        }

        private bool CanSubmitReview() => !string.IsNullOrWhiteSpace(NewReviewText) && Product != null;

        private void LoadReviewsFromDatabase()
        {
            if (Product == null) return;

            Product.Reviews.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT Rating, ReviewText FROM Reviews WHERE ProductId = @ProductId ORDER BY ReviewDate DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", Product.id);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int rating = reader.GetInt32(0);
                                string text = reader.GetString(1);
                                Product.Reviews.Add($"{rating}★: {text}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке отзывов: " + ex.Message);
            }
        }

        private void SubmitReview()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Reviews (UserId, ProductId, Rating, ReviewText)
                                     VALUES (@UserId, @ProductId, @Rating, @ReviewText)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", _currentUser.Id); 
                        command.Parameters.AddWithValue("@ProductId", Product.id);
                        command.Parameters.AddWithValue("@Rating", NewReviewRating);
                        command.Parameters.AddWithValue("@ReviewText", NewReviewText);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                Product.Reviews.Add($"{NewReviewRating}★: {NewReviewText}");
                NewReviewText = string.Empty;
                NewReviewRating = 5;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении отзыва: " + ex.Message);
            }
        }
        public void AddToCart(Product productToAdd)
        {
            if (productToAdd == null) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int cartId;

                        using (SqlCommand getCartCmd = new SqlCommand("SELECT CartId FROM Carts WHERE UserId = @UserId", conn, transaction))
                        {
                            getCartCmd.Parameters.AddWithValue("@UserId", _currentUser.Id);
                            var result = getCartCmd.ExecuteScalar();

                            if (result != null)
                                cartId = Convert.ToInt32(result);
                            else
                            {
                                using (SqlCommand createCartCmd = new SqlCommand("INSERT INTO Carts (UserId) OUTPUT INSERTED.CartId VALUES (@UserId)", conn, transaction))
                                {
                                    createCartCmd.Parameters.AddWithValue("@UserId", _currentUser.Id);
                                    cartId = (int)createCartCmd.ExecuteScalar();
                                }
                            }
                        }

                        int productId;
                        using (SqlCommand getProductCmd = new SqlCommand("SELECT Id FROM Goods WHERE Name = @Name AND Brand = @Brand", conn, transaction))
                        {
                            getProductCmd.Parameters.AddWithValue("@Name", productToAdd.Name);
                            getProductCmd.Parameters.AddWithValue("@Brand", productToAdd.Brand);
                            var productResult = getProductCmd.ExecuteScalar();

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

                            var quantityResult = checkItemCmd.ExecuteScalar();
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
