using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace lab4_5
{
    public class RegistrationViewModel : INotifyPropertyChanged
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

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set { _confirmPassword = value; OnPropertyChanged(nameof(ConfirmPassword)); }
        }

        public ICommand RegisterCommand { get; }

        public RegistrationViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register(object obj)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
            {
                MessageBox.Show("все поля должны быть заполнены");
                return;
            }
            if (Password != ConfirmPassword)
            {
                MessageBox.Show("пароли не совпадают");
                return;
            }

            var user = new User(Login, Password);
            var main = new MainWindow(user);
            main.Show();
            (obj as Window)?.Close(); // Закроет текущее окно
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}