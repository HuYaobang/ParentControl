using ParentControl.Views;
using System;
using System.Windows.Threading;

namespace ParentControl.Runtime
{
    class TimerMethods
    {
        public void InitializeTimer(int eyes, int eating, int exercise, int shutdown)
        {
            if (eyes != 0)
                EyesTimer(eyes);
            if (eating != 0)
                EatingTimer(eating);
            if (exercise != 0)
                ExerciseTimer(exercise);
            if (shutdown != 0)
                ShutDownTimer(shutdown);
        }

        public void EatingTimer(int frequency)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(frequency);
            timer.Tick += ShowEatingWindow;
            timer.Start();
        }

        public static void ShowEatingWindow(object sender, EventArgs e)
        {
            NotificationWindow notificationWindow = new NotificationWindow("eating", "Братишка, я тут покушать принёс");
            notificationWindow.Show();
        }

        public void EyesTimer(int frequency)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(frequency);
            timer.Tick += ShowEyesWindow;
            timer.Start();
        }

        public static void ShowEyesWindow(object sender, EventArgs e)
        {
            NotificationWindow notificationWindow = new NotificationWindow("eyes", "Пора делать глазную зарядочку");
            notificationWindow.Show();
        }

        public void ExerciseTimer(int frequency)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(frequency);
            timer.Tick += ShowExerciseWindow;
            timer.Start();
        }

        public static void ShowExerciseWindow(object sender, EventArgs e)
        {
            NotificationWindow notificationWindow = new NotificationWindow("exercise", "Пора делать тельную зарядочку");
            notificationWindow.Show();
        }

        public void ShutDownTimer(int time)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(time);
            timer.Tick += ShutDown;
            timer.Start();
        }

        public static void ShutDown(object sender, EventArgs e)
        {
            NotificationWindow notificationWindow = new NotificationWindow("shutdown", "Пора узреть реальный мир");
            notificationWindow.Show();
            System.Diagnostics.Process.Start("cmd", "/c shutdown -s -f -t 4");
        }
    }
}
