using ParentControl.Models;
using System;
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

namespace ParentControl.Views
{
    /// <summary>
    /// Логика взаимодействия для ConfirmPasswordWindow.xaml
    /// </summary>
    public partial class ConfirmPasswordWindow : Window
    {
        private UserInfoModel _user;
        private SignInMethods signIn;
        private SettingsWindow _settingsWindow;

        public ConfirmPasswordWindow(UserInfoModel user, SettingsWindow settingsWindow)
        {
            InitializeComponent();
            signIn = new SignInMethods();
            _settingsWindow = settingsWindow;
            _user = user;
        }

        private void LogInAccount(object sender, RoutedEventArgs e)
        {
            if (signIn.ConfirmUserLogIn(_user, Password.Password))
            {
                _settingsWindow.Show();
                this.Hide();
                Password.Password = String.Empty;
            }
            else
                MessageBox.Show("Incorrect password");
        }
    }
}
