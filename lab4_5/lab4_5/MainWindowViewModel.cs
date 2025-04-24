using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.ComponentModel;

namespace lab4_5
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private User _currentUser;
        private List<Product> _products;
        private List<Product> _sortedProducts;
        private List<Product> _foundProducts;
        private string _currentLanguage = "ru";

        public List<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        
    }
    public class DeleteProductCommand : ICommand
    {
        private readonly MainWindow _mainWindow;

        public DeleteProductCommand(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public bool CanExecute(object parameter) => parameter is Product;

        public void Execute(object parameter)
        {
            var productToRemove = parameter as Product;
            if (productToRemove != null)
            {
                var result = MessageBox.Show("Вы точно хотите удалить этот товар?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    // Perform product deletion here...
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }


}
