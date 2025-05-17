using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab4_5
{
    public class Product : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string ImagePath { get; set; }

        private string _buy;
        public string Buy
        {
            get { return _buy; }
            set
            {
                if (_buy != value)
                {
                    _buy = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _delete;
        public string Delete
        {
            get { return _delete; }
            set
            {
                if (_delete != value)
                {
                    _delete = value;
                    OnPropertyChanged();
                }
            }
        }

        public string BrandDescription { get; set; } = "Lorem ipsum dolor sit amet. Aut molestiae incidunt ea eius possimus At laboriosam rerum At fugit veritatis. Hic debitis veritatis et galisum nobis vel dolorum numquam ut provident ipsum et exercitationem vero eos temporibus dolore. ";
        public string Composition { get; set; } = "Lorem ipsum dolor sit amet. Aut molestiae incidunt ea eius possimus At laboriosam rerum At fugit veritatis. Hic debitis veritatis et galisum nobis vel dolorum numquam ut provident ipsum et exercitationem vero eos temporibus dolore. ";
        public double Price { get; set; }
        public Product(int id, string name, string description, string brand, string imagePath, string buy, string delete, double price, string composition)
        {
            this.id = id;
            Name = name;
            Description = description;
            Brand = brand;
            ImagePath = imagePath;
            Buy = buy;
            Delete = delete;
            Price = price;
            Composition = composition;
        }
        public Product(string name, string description, string brand, string imagePath, string buy, string delete, double price)
        {
            Name = name;
            Description = description;
            Brand = brand;
            ImagePath = imagePath;
            Buy = buy;
            Delete = delete;
            Price = price;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
