using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lab4_5
{
    class SettingsViewModel : INotifyPropertyChanged
    {
        private User CurrentUser;
        SettingsWindow SettingsWindow;
        public ICommand ChangeThemeCommand { get; }

        public SettingsViewModel(User user)
        {
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            CurrentUser = SettingsWindow.currentUser;
        }

        private int _currentThemeIndex = 0;
        private readonly string[] _themes =
        {
            "D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Themes\\DefaultTheme.xaml", // Тема по умолчанию
            "D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Themes\\DarkTheme.xaml",     // Темная тема
            "D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Themes\\BrownTheme.xaml"   // Дополнительная тема
        };
        private void ChangeTheme()
        {
            string themePath = _themes[_currentThemeIndex];

            var themeDict = new ResourceDictionary()
            {
                Source = new Uri(themePath, UriKind.Absolute)
            };

            var currentheme = Application.Current.Resources.MergedDictionaries
                              .FirstOrDefault(d => d.Source != null && d.Source.ToString().Contains("Themes"));

            if (currentheme != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(currentheme);
            }

            Application.Current.Resources.MergedDictionaries.Add(themeDict);

            _currentThemeIndex = (_currentThemeIndex + 1) % _themes.Length;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
