using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace lab4_5
{
    public class EditProfileViewModel
    {
        public Action CloseAction { get; set; }
        private User _user;
        private string _errorMessage;
        private string _profilePicBuffer;
        private BitmapImage _profileImage;
        private string _passwordBuffer;
        private string _username;
        public event Action<User> UserChanged;
        public ICommand BrowseImageCommand { get; set; }
        public string ImagePath { get; set; }

        public EditProfileViewModel()
        {
            BrowseImageCommand = new RelayCommand(BrowseImage);
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
