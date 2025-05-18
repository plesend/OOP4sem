using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private string connectionString = "Data Source=WIN-0RRORC9T71J\\SQLEXPRESS;Initial Catalog=CosmeticShop;TrustServerCertificate=Yes;Integrated Security=True;";

        private void Save()
        {
            bool isPasswordChanged = !string.IsNullOrWhiteSpace(newPassword) && newPassword != CurrentUser.Password;

            if (string.IsNullOrWhiteSpace(newUserName))
            {
                ErrorMessage = "Имя пользователя не может быть пустым.";
                return;
            }

            if (isPasswordChanged)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Вы действительно хотите изменить пароль?",
                    "Подтверждение изменения пароля",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes)
                {
                    ErrorMessage = "Изменение пароля отменено.";
                    return;
                }

                string inputPassword = Microsoft.VisualBasic.Interaction.InputBox(
                    "Введите текущий пароль для подтверждения:",
                    "Подтверждение пароля",
                    "");

                if (inputPassword != CurrentUser.Password)
                {
                    ErrorMessage = "Неверный текущий пароль.";
                    return;
                }
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string updateQuery = @"
                UPDATE Users
                SET Username = @Username,
                    Pfp = @Pfp" +
                            (isPasswordChanged ? ", Password = @Password" : "") + @"
                WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@Username", newUserName);
                    cmd.Parameters.AddWithValue("@Pfp", Pfp);
                    cmd.Parameters.AddWithValue("@Id", CurrentUser.Id);

                    if (isPasswordChanged)
                        cmd.Parameters.AddWithValue("@Password", newPassword);

                    cmd.ExecuteNonQuery();

                    CurrentUser.Username = newUserName;
                    CurrentUser.Pfp = Pfp;
                    if (isPasswordChanged)
                        CurrentUser.Password = newPassword;

                    ErrorMessage = "Данные успешно обновлены!";
                    UserChanged?.Invoke(CurrentUser);
                    CloseAction?.Invoke();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Ошибка при сохранении: {ex.Message}";
            }
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
