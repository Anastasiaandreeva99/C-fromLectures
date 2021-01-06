using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha2Lab9b
{
   public class AlarmEventArgs:EventArgs
    { // Event object
        private int nrings;
        public AlarmEventArgs(int nrings)
        {
            NRings = nrings;
        }
        public int NRings
        {
            get { return nrings; }
            set { nrings = value > 0? value : 1; }
        }

    }
}
