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
using System.Threading;
using WpfAnimatedGif;
using System.Windows.Threading;

namespace ParentControl.Views
{
    /// <summary>
    /// Логика взаимодействия для NotificationWindow.xaml
    /// </summary>
    public partial class NotificationWindow : Window
    {
        public NotificationWindow(string path, string message)
        {
            InitializeComponent();
            Message.Content = message;
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(System.IO.Path.GetFullPath(String.Format(@"Images\{0}.gif",path)));
            image.EndInit();
            ImageBehavior.SetAnimatedSource(Img, image);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartCloseTimer();
        }

        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(4d);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            Close();
        }
    }
}
