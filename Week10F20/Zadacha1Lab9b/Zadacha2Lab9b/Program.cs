using System;
using System.ComponentModel;

namespace Zadacha2Lab9b
{
    class Program
    { // Subscriber
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock();
            clock.Alarm += OnRing1;
            clock.Alarm += OnRing2;
            clock.PropertyChanged += OnPropertyChanged;
            clock.Rings = 5;
            clock.RingTime =  3000;// fire PropertyChanged event
            clock.Start();
        }

        private static void OnRing1(object sender, EventArgs args)
        {
            int rings = ((AlarmEventArgs)args).NRings;
            Console.WriteLine("Ring1: {0}", rings);
        }
        private static void OnRing2(object sender, EventArgs args)
        {
            int rings = ((AlarmEventArgs)args).NRings;
            Console.WriteLine("Ring2: {0}", rings);
        }
        private static void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            Console.WriteLine("New ringtime setup. {0} set to {1}.",
                                                       args.PropertyName, 
                                                       ((AlarmClock)sender).RingTime);
        }
    }
}
