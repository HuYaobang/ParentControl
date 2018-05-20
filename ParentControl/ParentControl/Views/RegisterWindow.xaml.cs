using ParentControl.Models;
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
using System.Windows.Shapes;

namespace ParentControl.View
{
    public partial class RegisterWindow : Window
    {
        private RegisterMethods registerMethods;
        private UserInfoModel user;

        public RegisterWindow()
        {
            InitializeComponent();
            registerMethods = new RegisterMethods();
            user = new UserInfoModel();
        }

        private void RedirectToEmailConfirmationWindow(object sender, RoutedEventArgs e, UserInfoModel user)
        {
            EmailConfirmationWindow emailConfirmationWindow = new EmailConfirmationWindow(user);
            emailConfirmationWindow.Show();
            this.Close();
        }

        private void BackToSignInWindow(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            signInWindow.Show();
            this.Close();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            user.Email = Email.Text;
            user.Password = Password.Text;
            if (registerMethods.Register(user, new string[] { Password.Text, PasswordConfirmation.Text }))
            {
                MessageBox.Show("Регистрация прошла успешно");
                RedirectToEmailConfirmationWindow(sender,e,user);
            }
        }
    }
}
