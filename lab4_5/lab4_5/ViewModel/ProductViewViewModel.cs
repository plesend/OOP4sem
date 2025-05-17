using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab4_5
{
    class ProductViewViewModel : INotifyPropertyChanged
    {
        private Product _product;

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
                }
            }
        }
        

        public string Name => Product?.Name;
        public string Description => Product?.Description;
        public string Brand => Product?.Brand;
        public string ImagePath => Product?.ImagePath;
        public string Buy => Product?.Buy;
        public string Delete => Product?.Delete;
        public double Price => Product?.Price ?? 0;
        public string Composition => Product?.Composition;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
