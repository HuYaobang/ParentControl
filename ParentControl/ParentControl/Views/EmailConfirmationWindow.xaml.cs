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
    public partial class EmailConfirmationWindow : Window
    {
        private UserInfoModel user;
        private EmailConfirmationMethods emailConfirmation;
        private int confirmationKey;

        public EmailConfirmationWindow(UserInfoModel user)
        {
            InitializeComponent();
            this.user = user;
            emailConfirmation = new EmailConfirmationMethods();
            confirmationKey = emailConfirmation.GenerateConfirmationKey();
            emailConfirmation.SendEmail(user, confirmationKey);
        }

        private void CheckConfirmationKey(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(ConfirmationKey.Text) == confirmationKey)
            {
                if (emailConfirmation.UpdateConfirmationStatus(user))
                {
                    SettingsWindow settingsWindow = new SettingsWindow(user);
                    settingsWindow.Show();
                    this.Close();
                }
            }
            else
                MessageBox.Show("Неверный код подтверждения.");            
        }

        private void ResendConfirmationKey(object sender, RoutedEventArgs e)
        {
            confirmationKey = emailConfirmation.GenerateConfirmationKey();
            emailConfirmation.SendEmail(user, confirmationKey);
            MessageBox.Show("Новый код подтверждения был выслан на Вашу электронную почту.");
        }
    }
}
