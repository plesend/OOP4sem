using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static lab4_5.MainWindowViewModel;

namespace lab4_5
{
    public class CartItemViewModel : INotifyPropertyChanged
    {
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; } 


        public double Total => Price * Quantity;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public class CartWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CartItemViewModel> CartItems { get; set; } = new();
        public double TotalAmount => CartItems.Sum(item => item.Total);

        public string connectionString = "Data source = WIN-0RRORC9T71J\\SQLEXPRESS; Initial Catalog = CosmeticShop;TrustServerCertificate=Yes;Integrated Security=True;";
        private int userId;

        public ICommand RemoveProductFromCartCommand { get; }
        public ICommand ClearCartCommand { get; }
        public ICommand IncreaseQuantityCommand { get; }
        public ICommand DecreaseQuantityCommand { get; }
        public ICommand OpenOrderWindowCommand { get; }
        public CartWindowViewModel(User user)
        {
            userId = user.Id;
            RemoveProductFromCartCommand = new RelayCommand<CartItemViewModel>(DelProductFromCart);
            ClearCartCommand = new RelayCommand(ClearCart);
            OpenOrderWindowCommand = new RelayCommand(OpenOrderWindow);
            IncreaseQuantityCommand = new RelayCommand<CartItemViewModel>(IncreaseQuantity);
            DecreaseQuantityCommand = new RelayCommand<CartItemViewModel>(DecreaseQuantity);
            LoadCartItems(user);
        }

        public void LoadCartItems(User user)
        {
            CartItems.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
SELECT g.Id AS ProductId, c.CartId, g.Name, g.Brand, g.Price, g.ImagePath, ci.Quantity
FROM CartItems ci
JOIN Carts c ON ci.CartId = c.CartId
JOIN Goods g ON ci.ProductId = g.Id
WHERE c.UserId = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", user.Id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CartItems.Add(new CartItemViewModel
                            {
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                CartId = Convert.ToInt32(reader["CartId"]),
                                ProductName = reader["Name"].ToString(),
                                Brand = reader["Brand"].ToString(),
                                Price = Convert.ToDouble(reader["Price"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                ImagePath = reader["ImagePath"].ToString()
                            });
                        }
                    }
                }
            }

            OnPropertyChanged(nameof(CartItems));
            OnPropertyChanged(nameof(TotalAmount));
        }

        public void DelProductFromCart(CartItemViewModel itemToRemove)
        {
            if (itemToRemove != null)
            {
                var result = MessageBox.Show("Вы точно хотите удалить этот товар?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM CartItems WHERE CartId = @CartId AND ProductId = @ProductId", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CartId", itemToRemove.CartId);
                            cmd.Parameters.AddWithValue("@ProductId", itemToRemove.ProductId);

                            try
                            {
                                int rowsAffected = cmd.ExecuteNonQuery();
                                transaction.Commit();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Товар удален из базы данных!");
                                    CartItems.Remove(itemToRemove);
                                    OnPropertyChanged(nameof(TotalAmount));
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
        public void IncreaseQuantity(CartItemViewModel item)
        {
            if (item == null) return;

            item.Quantity++;
            UpdateQuantityInDb(item);
            OnPropertyChanged(nameof(TotalAmount));
        }
        public void DecreaseQuantity(CartItemViewModel item)
        {
            if (item == null) return;

            item.Quantity--;
            UpdateQuantityInDb(item);
            OnPropertyChanged(nameof(TotalAmount));
        }

        private void UpdateQuantityInDb(CartItemViewModel item)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE CartItems SET Quantity = @Quantity WHERE CartId = @CartId AND ProductId = @ProductId", conn))
                {
                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd.Parameters.AddWithValue("@CartId", item.CartId);
                    cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ClearCart()
        {
            var result = MessageBox.Show("Вы точно хотите очистить корзину?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                DELETE ci
                FROM CartItems ci
                JOIN Carts c ON ci.CartId = c.CartId
                WHERE c.UserId = @UserId";

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                            MessageBox.Show("Корзина очищена");
                            CartItems.Clear();
                            OnPropertyChanged(nameof(TotalAmount));
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Ошибка при очистке корзины: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void OpenOrderWindow()
        {
            var orderWindow = new OrderWindow(userId, CartItems);

            orderWindow.ShowDialog();

            LoadCartItems(new User { Id = userId });
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
