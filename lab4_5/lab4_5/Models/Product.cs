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
        public int Price { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
