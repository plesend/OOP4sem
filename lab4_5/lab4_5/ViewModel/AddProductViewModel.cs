using lab4_5;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System;
using System.IO;

public class AddProductViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private readonly MainWindow mainWindow;

    public string Name { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public string PriceText { get; set; }
    public string ImagePath { get; set; }

    public RelayCommand AddProductCommand { get; }
    public RelayCommand BrowseImageCommand { get; }

    public AddProductWindow CurrentWindow { get; set; } // чтобы закрывать окно из ViewModel

    public AddProductViewModel(MainWindow main)
    {
        mainWindow = main;

        AddProductCommand = new RelayCommand(_ => AddProduct());
        BrowseImageCommand = new RelayCommand(_ => BrowseImage());
    }

    private void AddProduct()
    {
        if (string.IsNullOrWhiteSpace(Name) ||
            string.IsNullOrWhiteSpace(Type) ||
            string.IsNullOrWhiteSpace(Brand) ||
            string.IsNullOrWhiteSpace(PriceText) ||
            string.IsNullOrWhiteSpace(ImagePath))
        {
            MessageBox.Show("Пожалуйста, заполните все поля.");
            return;
        }

        if (!int.TryParse(PriceText, out int price))
        {
            MessageBox.Show("Цена должна быть числом.");
            return;
        }

        var newProduct = new Product
        {
            Name = Name,
            Description = Type,
            Brand = Brand,
            ImagePath = ImagePath,
            Price = price
        };

        string jsonPath = "D:\\лабораторные работы\\ооп\\lab4_5\\pics\\products.json";

        try
        {
            List<Product> allProducts = new List<Product>();

            if (File.Exists(jsonPath))
            {
                string existingJson = File.ReadAllText(jsonPath);
                allProducts = JsonConvert.DeserializeObject<List<Product>>(existingJson) ?? new List<Product>();
            }

            allProducts.Add(newProduct);

            string updatedJson = JsonConvert.SerializeObject(allProducts, Formatting.Indented);
            File.WriteAllText(jsonPath, updatedJson);

            mainWindow.products = allProducts;
            mainWindow.CatalogPanel.Children.Clear();
            mainWindow.LoadProducts(mainWindow.products, mainWindow.currentUser);

            CurrentWindow?.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при работе с JSON: {ex.Message}");
        }
    }

    private void BrowseImage()
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Изображения (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|Все файлы (*.*)|*.*",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        };

        if (dialog.ShowDialog() == true)
        {
            ImagePath = dialog.FileName.Replace("\\", "/");
            OnPropertyChanged(nameof(ImagePath));
        }
    }

    private void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
