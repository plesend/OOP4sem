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

namespace lab4_5
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string ImagePath { get; set; }

        public int Price { get; set; }
       
    }
}
