﻿using System;
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
using System.Windows.Shapes;

namespace lab4_5
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            DataContext = new AuthorizationViewModel();
        }

        //private void LoginButton_Click(object sender, RoutedEventArgs e)
        //{
        //    string login = Login.Text;
        //    string password = Password.Text;

        //    User user = new User(login, password);

        //    MainWindow mainWindow = new MainWindow(user);
        //    mainWindow.Show();
        //    this.Close();
        //}
    }
}
