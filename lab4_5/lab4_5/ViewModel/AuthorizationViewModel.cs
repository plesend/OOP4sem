using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace lab4_5
{
    public class AuthorizationViewModel : INotifyPropertyChanged
    {
        private string _login;
        public string Login
        {
            get => _login;
            set { _login = value; OnPropertyChanged(nameof(Login)); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public ICommand LoginCommand { get; }

        public AuthorizationViewModel()
        {
            LoginCommand = new RelayCommand(LogIn);
        }

        private void LogIn(object obj)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            if ((Login == "qwerty" && Password == "1234") ||
                (Login == "йцукен" && Password == "1234"))
            {
                User user = new User(Login, Password);
                MainWindow main = new MainWindow(user);
                main.Show();
                (obj as Window)?.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Доступ разрешен только для Админа и Клиента.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
