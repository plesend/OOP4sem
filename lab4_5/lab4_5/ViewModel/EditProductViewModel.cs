using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace lab4_5
{
    public class EditProductViewModel : INotifyPropertyChanged
    {
        private Product _product;
        public Product UpdatedProduct { get; set; }
        public Product Product
        {
            get => _product;
            set { _product = value; OnPropertyChanged(); }
        }

        public string PriceText
        {
            get => Product?.Price.ToString("F2");
            set
            {
                if (double.TryParse(value, out double price))
                {
                    if (Product.Price != price)
                    {
                        Product.Price = price;
                        OnPropertyChanged();
                    }
                }
                else if (!string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Цена должна быть числом.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        public string ImagePath
        {
            get => Product?.ImagePath;
            set
            {
                if (Product != null && Product.ImagePath != value)
                {
                    Product.ImagePath = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand BrowseImageCommand { get; }
        public ICommand SaveProductCommand { get; }

        private readonly string connectionString = "Data Source=WIN-0RRORC9T71J\\SQLEXPRESS;Initial Catalog=CosmeticShop;Integrated Security=True;TrustServerCertificate=True;";

        public EditProductViewModel(Product product)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            BrowseImageCommand = new RelayCommand(_ => BrowseImage());
            SaveProductCommand = new RelayCommand(_ => SaveProduct());
        }

        private void BrowseImage()
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (dlg.ShowDialog() == true)
            {
                ImagePath = dlg.FileName;
            }
        }

        private void SaveProduct()
        {
            if (Product == null || Product.id == 0)
            {
                MessageBox.Show("Ошибка: Товар не выбран.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Валидация обязательных полей
            if (string.IsNullOrWhiteSpace(Product.Name) ||
                string.IsNullOrWhiteSpace(Product.Brand) ||
                string.IsNullOrWhiteSpace(Product.ImagePath))
            {
                MessageBox.Show("Пожалуйста, заполните обязательные поля: название, бренд и путь к изображению.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Product.Price <= 0)
            {
                MessageBox.Show("Цена должна быть положительным числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var transaction = conn.BeginTransaction();

                try
                {
                    // Проверка или добавление бренда
                    int brandId;
                    using (var checkBrandCmd = new SqlCommand("SELECT BrandId FROM Brands WHERE BrandName = @BrandName", conn, transaction))
                    {
                        checkBrandCmd.Parameters.AddWithValue("@BrandName", Product.Brand);
                        var result = checkBrandCmd.ExecuteScalar();

                        if (result != null)
                        {
                            brandId = Convert.ToInt32(result);
                        }
                        else
                        {
                            using var insertBrandCmd = new SqlCommand(
                                "INSERT INTO Brands (BrandName) OUTPUT INSERTED.BrandId VALUES (@BrandName)", conn, transaction);
                            insertBrandCmd.Parameters.AddWithValue("@BrandName", Product.Brand);
                            brandId = (int)insertBrandCmd.ExecuteScalar();
                        }
                    }

                    // Обновление товара
                    const string updateQuery = @"
                UPDATE Goods
                SET Name = @Name,
                    Description = @Description,
                    Brand = @Brand,
                    ImagePath = @ImagePath,
                    Price = @Price,
                    Composition = @Composition,
                    BrandId = @BrandId
                WHERE Id = @Id";

                    using var cmd = new SqlCommand(updateQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@Id", Product.id);
                    cmd.Parameters.AddWithValue("@Name", Product.Name);
                    cmd.Parameters.AddWithValue("@Description", (object?)Product.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Brand", (object?)Product.Brand ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ImagePath", (object?)Product.ImagePath ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Price", Product.Price);
                    cmd.Parameters.AddWithValue("@Composition", (object?)Product.Composition ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrandId", brandId);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show("Товар успешно обновлён.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Закрываем окно с положительным результатом
                    if (Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive) is Window currentWindow)
                    {
                        currentWindow.DialogResult = true;
                        currentWindow.Close();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Ошибка при сохранении товара: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
