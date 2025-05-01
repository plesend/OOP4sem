using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_5
{
    public class User : INotifyPropertyChanged
    {
        private string _role;
        private string _login;
        private string _username = "User";
        private string _password;
        private string _pfp = "D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Resources\\DefaultPfp.png";

        public string Role
        {
            get => _role;
            set { _role = value; OnPropertyChanged(nameof(Role)); }
        }

        public string Login
        {
            get => _login;
            set { _login = value; OnPropertyChanged(nameof(Login)); }
        }

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string Pfp
        {
            get => _pfp;
            set { _pfp = value; OnPropertyChanged(nameof(Pfp)); }
        }

        public User(string login, string password)
        {
            Login = login;
            Password = password;

            if (login == "qwerty" && password == "1234")
            {
                Role = "Admin";
            }
            else if (login == "йцукен" && password == "1234")
            {
                Role = "Client";
            }
            else
            {
                Role = "Client";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
