using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha2Lab9b
{
    public class AlarmClock :INotifyPropertyChanged
    {   // Publisher: event source
        // Publish the Alarm event
        public event EventHandler Alarm;
        public event PropertyChangedEventHandler PropertyChanged;

        private int rings; // number of rings
        private int ringTime;  // delay for time to ring
        public int RingTime
        {
            get
            {
                return ringTime;
            }
            set
            {
                ringTime = value >= 0 ? value : 0;
              
                if(ringTime >0) PropertyChanged?.Invoke(this,
                                       new PropertyChangedEventArgs(nameof(RingTime)));
            }
        }
        public int Rings
        {
            get { return rings; }
            set { rings = value >= 0 ? value : 0; }
        }

        protected void OnAlarm(AlarmEventArgs e)
        {
            //Invoke the event handler.
            Alarm?.Invoke(this, e);
        }

        // event invoking method
        public void Start()
        {  // wait for time to ring
            using (var task = Task.Delay(ringTime))
            {
                task.Wait();
            }
            for (; ; )
            {  // start ringing
                rings--;
                if (rings < 0)
                {

                    break;
                }

                else
                {   // ring as subscriber has defined
                    AlarmEventArgs e = new AlarmEventArgs(rings);
                    Alarm?.Invoke(this, e);
                }
            }
        }
    }
}
