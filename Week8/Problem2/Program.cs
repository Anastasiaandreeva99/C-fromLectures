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
            Point point1 = new Point();
            Console.WriteLine(point1);
            Point point2 = new Point(10,10,10);
            Console.WriteLine(point2);
            Vector v = new Vector(point1, point2);
            Console.WriteLine(v);

        }
    }
}
