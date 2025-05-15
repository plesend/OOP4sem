using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lab4_5
{
    class UserViewModel : INotifyPropertyChanged
    {
        public string ConnectionString = "Data source = WIN-0RRORC9T71J\\SQLEXPRESS; Initial Catalog = CosmeticShop;TrustServerCertificate=Yes;Integrated Security=True;";

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users {
            get => _users;
            set { _users = value; OnPropertyChanged(); }
        }
        public UserViewModel()
        {
            LoadUsers();
        }

        public void LoadUsers()
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("select * from Users", connection);
                using (var reader = command.ExecuteReader())
                {
                    var users = new ObservableCollection<User>();
                    while(reader.Read())
                    {
                        users.Add(new User
                            (
                                role: reader["Role"].ToString(),
                                login: reader["Login"].ToString(),
                                username: reader["Username"].ToString(),
                                password: reader["Password"].ToString(),
                                pfp: reader["Pfp"].ToString()
                            ));
                    }
                    Users = users;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
