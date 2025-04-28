using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;

namespace lab4_5
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        User user {  get; set; }
        public RegistrationWindow()
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(Password.Text) || string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(ConfirmPassword.Text))
        //    {
        //        MessageBox.Show("все поля должны быть заполнены");

        //        return;
        //    }
        //    if(Password.Text != ConfirmPassword.Text)
        //    {
        //        MessageBox.Show("пароли не совпадают");
        //        return;
        //    }
        //    this.user = new User(Login.Text, Password.Text);
        //    var newWindow = new MainWindow(this.user);//передать юзера
        //    this.Close();
        //    newWindow.Show();


        //}
    }
}
