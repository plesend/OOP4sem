using lab4_5;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public class AddProductViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private readonly MainWindow mainWindow;

    public string Name { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public string PriceText { get; set; }
    public string ImagePath { get; set; }
    public Product newProductReturned { get; set; }

    public Action CloseAction { get; set; }
    public RelayCommand AddProductCommand { get; }
    public RelayCommand BrowseImageCommand { get; }

    public AddProductViewModel()
    {
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

        Product newProduct = new Product
        {
            Name = Name,
            Description = Type,
            Brand = Brand,
            ImagePath = ImagePath,
            Price = price
        };

        newProductReturned = newProduct;
        CloseAction?.Invoke();
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
