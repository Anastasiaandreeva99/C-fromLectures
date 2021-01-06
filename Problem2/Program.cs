using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            CosSeries cos = new CosSeries();
            cos.Accuracy = 0.0000001;
            cos.Parameter = Math.PI / 4;

            Console.WriteLine($"Accurate: {Math.Cos(cos.Parameter)}");
            Console.WriteLine($"Approx: {cos.CosineValue()}");
        }
    }
}
