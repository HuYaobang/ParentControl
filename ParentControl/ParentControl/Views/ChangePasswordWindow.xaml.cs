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
    public partial class ChangePasswordWindow : Window
    {
        private UserInfoModel _user;
        private ChangePasswordMethods changePassword;

        public ChangePasswordWindow(UserInfoModel user)
        {
            InitializeComponent();
            _user = user;
            changePassword = new ChangePasswordMethods();
        }

        private void ChangeUserPassword(object sender, RoutedEventArgs e)
        {
            if ((changePassword.ChangePasswordInDb(_user, new string[] { OldPassword.Text,
                NewPassword.Text, ConfirmPassword.Text })))
                _user.Password = NewPassword.Text;
            else
                MessageBox.Show("Error called while changing password");

        }

        private void RedirectToSettingsWindow(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow(_user);
            settingsWindow.Show();
            this.Close();
        }
    }
}
