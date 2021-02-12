using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ClockApp
{
    /// <summary>
    /// Interaction logic for ClockUsrControl.xaml
    /// </summary>
    public partial class ClockUsrControl : UserControl
    {
        private bool suspended;
        public ClockUsrControl()
        {
            InitializeComponent();
            suspended = false;
            Thread tick = new Thread(Ticktac);
            tick.Start();
        }

        private void Ticktac()
        {
            if (SecondHand == null ||
                MinuteHand == null ||
                HourHand == null) return;
            while (true)
            {
                SetTime();
                Thread.Sleep(1000);
                lock (this)
                {
                    while (suspended)
                    {
                        Monitor.Wait(this);

                    }
                }
            }
        }
        public void Suspend()
        {
            suspended = true;
        }
        public void Resume()
        {
            lock (this)
            {
                suspended = false;
                Monitor.PulseAll(this);
            }
            
        }
        private void SetTime()
        {
            try
            {
                this.Dispatcher.Invoke(
                     new Action(() =>
                    {
                        int secs, mins, hrs;
                        secs = DateTime.Now.Second;
                        mins = DateTime.Now.Minute;
                        hrs = DateTime.Now.Hour;
                        SecondHand.Angle = secs * 6;
                        MinuteHand.Angle = mins * 6;
                        HourHand.Angle = hrs * 30 + mins * 0.5;

                    }));
            }
            catch (TaskCanceledException)
            {
                Dispatcher.InvokeShutdown();
                System.Environment.Exit(0);
            }
        }
    }
}
