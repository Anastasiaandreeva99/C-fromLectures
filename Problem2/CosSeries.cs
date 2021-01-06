using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class CosSeries
    {
        private double accuracy;
        public double Parameter { get; set; }

        public CosSeries()
        {
            Parameter = 0;
            accuracy = 0.01;
        }
        public double Accuracy
        {
            get { return accuracy; }
            set { accuracy = value>0 &&value<1?value: 0.01; }
        }
        public double CosineValue()
        {
            double value = 0;
            double term = 1;
            int sign = 1;
            int counter = 1;

            do
            {
                value += term;
                term = -term * Parameter * Parameter / ((counter + 1) * (counter));
                counter += 2;
            } while (Math.Abs(term) > accuracy);
            value += term;
            return value;
        }

    }
}
