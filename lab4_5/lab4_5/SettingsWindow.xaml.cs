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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow(User user)
        {
            try
            {
                InitializeComponent();
                DataContext = new SettingsViewModel(user);
            }
            catch (Exception ex) {  MessageBox.Show(ex.Message); }
        }
    }
}
