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
    public class EditProfileViewModel : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        public event Action<User> UserChanged;
        private User _currentUser;
        private string _newUserName;
        private string _newPassword;
        private string _errorMessage;
        private string _profilePicBuffer;

        public event PropertyChangedEventHandler PropertyChanged;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        public string Pfp
        {
            get => _profilePicBuffer;
            set
            {
                _profilePicBuffer = value;
                OnPropertyChanged();
            }
        }

        public string newUserName
        {
            get => _newUserName;
            set
            {
                _newUserName = value;
                OnPropertyChanged();
            }
        }

        public string newPassword
        {
            get => _newPassword;
            set
            {
                _newPassword = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand ChangeProfileImageCommand { get; }

        public EditProfileViewModel(User currentUser)
        {
            CurrentUser = currentUser;
            newUserName = currentUser.Username;
            _profilePicBuffer = currentUser.Pfp;

            SaveCommand = new RelayCommand(Save);
            CloseCommand = new RelayCommand(Close);
            ChangeProfileImageCommand = new RelayCommand(ChangeProfileImage);
        }

        private void Save()
        {
            if (string.IsNullOrEmpty(newUserName) || string.IsNullOrEmpty(newPassword))
            {
                ErrorMessage = "Все поля должны быть заполнены.";
                return;
            }

            if (newPassword != CurrentUser.Password)
            {
                ErrorMessage = "Пароль неверный.";
                return;
            }

            CurrentUser.Username = newUserName;
            CurrentUser.Pfp = Pfp;

            // Тут может быть логика сохранения изменений в БД или другом хранилище.

            ErrorMessage = "Данные сохранены!";
            CloseAction?.Invoke();

        }

        private void Close()
        {
            CurrentUser.Username = newUserName;
            CurrentUser.Pfp = Pfp;

            CloseAction?.Invoke();
        }

        private void ChangeProfileImage()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                Pfp = dialog.FileName;
            }
        }

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
