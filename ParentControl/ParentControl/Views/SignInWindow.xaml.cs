using ParentControl.Models;
using ParentControl.View;
using ParentControl.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParentControl
{
    public partial class SignInWindow : Window
    {
        private SignInMethods signInMethods;

        public SignInWindow()
        {
            InitializeComponent();
            signInMethods = new SignInMethods();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            if(signInMethods.SignInSuccess(new string[] { Email.Text,Password.Password}))
            {
                SettingsWindow settingsWIndow = new SettingsWindow(new UserInfoModel { Email = Email.Text, Password = Password.Password});
                settingsWIndow.Show();
                this.Close();
            }

        }
    }
}
