using Hardcodet.Wpf.TaskbarNotification;
using ParentControl.Commands;
using ParentControl.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Threading;
using ParentControl.Runtime;


namespace ParentControl.Views
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        UserInfoModel _user;
        EmailConfirmationMethods emailConfirmation;
        UserSettingsMethods userSettings;
        ConfirmPasswordWindow confirmPasswordWindow;
        Runtime.Runtime runtime;
        public static TaskbarIcon TbIcon { get; protected set; }

        public SettingsWindow(UserInfoModel user)
        {
            InitializeComponent();
            emailConfirmation = new EmailConfirmationMethods();
            userSettings = new UserSettingsMethods();
            _user = user;
            InitializeUserSettings();
            confirmPasswordWindow = new ConfirmPasswordWindow(_user, this);
            Email.Content = _user.Email;
            runtime = new Runtime.Runtime(_user.EyesTimer, _user.EatingTimer, _user.ExerciseTimer, _user.ShutDownTimer);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!emailConfirmation.UserEmailConfirmed(_user))
            {
                emailConfirmation.RedirectToEmailConfirmation(_user);
                this.Close();
            }
            TbIcon = new TaskbarIcon();
            TbIcon.DoubleClickCommandParameter = confirmPasswordWindow;
            TbIcon.DoubleClickCommand = new ShowFromTrayCommand();            
            TbIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(@"D:\ООП\ParentControl\ParentControl\ParentControl\Resources\icon.ico");
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            signInWindow.Show();
            this.Close();
            confirmPasswordWindow.Close();
            runtime = null;
            TbIcon.Dispose();
        }

        private void RedirectToChangePasswordWindow(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow(_user);
            changePasswordWindow.Show();
            this.Close();
        }

        private void InitializeUserSettings()
        {
            _user = userSettings.GetUserSettingsFromDb(_user);
            EnableAutoStart.IsChecked = _user.EnableAutoStart;
            UseShutDownTimer.IsChecked = _user.UseShutDownTimer;
            UseEatingTimer.IsChecked = _user.UseEatingTimer;
            UseExerciseTimer.IsChecked = _user.UseExerciseTimer;
            UseEyesTimer.IsChecked = _user.UseEyesTimer;
            ShutDownTimer.Value = _user.ShutDownTimer;
            EatingTimer.Value = _user.EatingTimer;
            ExerciseTimer.Value = _user.ExerciseTimer;
            EyesTimer.Value = _user.EyesTimer;
            userSettings.CheckAutoStart(_user.EnableAutoStart);
        }

        private void SaveNewSettings(object sender, RoutedEventArgs e)
        {
            _user.EnableAutoStart = (bool)EnableAutoStart.IsChecked;
            _user.UseShutDownTimer = (bool)UseShutDownTimer.IsChecked;
            _user.UseEatingTimer = (bool)UseEatingTimer.IsChecked;
            _user.UseExerciseTimer = (bool)UseExerciseTimer.IsChecked;
            _user.UseEyesTimer = (bool)UseEyesTimer.IsChecked;
            _user.ShutDownTimer = Convert.ToInt32(ShutDownTimer.Value);
            _user.EatingTimer = Convert.ToInt32(EatingTimer.Value);
            _user.ExerciseTimer = Convert.ToInt32(ExerciseTimer.Value);
            _user.EyesTimer = Convert.ToInt32(EyesTimer.Value);
            if (userSettings.SaveUserSettingsInDb(_user))
            {
                System.Windows.MessageBox.Show("Настройки сохранены.");
                InitializeUserSettings();
                runtime.SaveRuntimeChanges(_user.EyesTimer, _user.EatingTimer, _user.ExerciseTimer, _user.ShutDownTimer);
            }
            else
                System.Windows.MessageBox.Show("Возникла ошибка при сохранении настроек.");
        }

    }
}
