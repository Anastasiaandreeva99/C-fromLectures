using Problem2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2test
{
    public static class Extension
    {
        public static double Perimeter( this Rectangle rectangle)
        {
            int deltaX = 
                Math.Abs(rectangle.UpperLeftPoint[0] - rectangle.LowerRightPoint[0]);
            int deltaY = 
               Math.Abs(rectangle.UpperLeftPoint[1] - rectangle.LowerRightPoint[1]);
            return 2*(deltaX + deltaY);
        }

        public static Rectangle Translate(this Rectangle rectangle, int xDirection)
        {  
            Point p1 = rectangle.UpperLeftPoint;
            Point p2 = rectangle.LowerRightPoint;
            p1[0]  += xDirection;
            p2[0]  += xDirection;
             
            return rectangle;
        }
    }
}
