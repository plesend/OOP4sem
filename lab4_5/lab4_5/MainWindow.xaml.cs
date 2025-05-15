using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections;
using System.Reflection;

namespace lab4_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User user { get; set; }

        public User currentUser;

        public MainWindow(User user)
        {
            InitializeComponent();
            currentUser = user;

            if (currentUser.Role != "Admin")
            {
                AddProduct.Visibility = Visibility.Collapsed;

            }

            DataContext = new MainWindowViewModel(currentUser);
        }

        
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumeric(e.Text);
        }

        private void NumberOnly_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextNumeric(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private bool IsTextNumeric(string text)
        {
            return text.All(char.IsDigit);
        }

        private void Banner_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct.ContextMenu.PlacementTarget = AddProduct;
            AddProduct.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            AddProduct.ContextMenu.IsOpen = true;
        }


        private void EventButton_IconClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("IconClick (Direct) handled in MainWindow");
        }
    }
}
