using System;
using System.Windows;
using System.Windows.Threading;

namespace ClockDispatcherTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();

            var time = DateTime.Now;
            LblDigitalClock.Content = $"{time.Hour:D2}:{time.Minute:D2}:{time.Second:D2}";
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(OnTimeElapsed);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            //timer.Stop();
        }

        private void OnTimeElapsed(object sender, EventArgs args)
        {
            int secs, mins, hrs;
            secs = DateTime.Now.Second;
            mins = DateTime.Now.Minute;
            hrs = DateTime.Now.Hour;
            LblDigitalClock.Content = $"{hrs:D2}:{mins:D2}:{secs:D2}";
        }
    }
}
