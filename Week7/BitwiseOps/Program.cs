using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitwiseOps
{
    class Program
    {
        static void Main(string[] args)
        {
            IntBits ib = new IntBits(8);
            Console.WriteLine("Show bits:");
            Console.WriteLine(ib);
            ib[10] = 1;
            Console.WriteLine("Show bit 10:");
            Console.WriteLine(ib[10]);
            Console.WriteLine("Show bits:");
            Console.WriteLine(ib);
        }
    }
}
