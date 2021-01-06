using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Rectangle
    {
        public delegate double CompareBy(double w, double l);
        private double width;
        private double length;
        private Point leftPoint;
        public readonly string R_ID;
        private static long cnt = 1;
        private static char[] symbols = { 'x', 'y', 'w', 'h' }; 

        #region Constructors 
        public Rectangle(double width, double length, Point leftPoint)
        {
            Width = width;
            Length = length;
            LeftPoint = leftPoint;
            R_ID = string.Format("R{0:D6}", cnt++);
            //  R_ID = $"{(cnt++):D6})";
        }
        public Rectangle() : this(0, 0, new Point())
        {

        }
        public Rectangle(Rectangle rectangle) : this(rectangle.width,
                                                    rectangle.length,
                                                    rectangle.leftPoint)
        { }


            #endregion}
        #region Properties

        public Point LeftPoint
        {
            get { return new Point(leftPoint); }
            set { leftPoint = value != null ? new Point(value) : new Point(); }
        }

        public double Length
        {
            get { return length; }
            set { length = value >= 0 ? value : 0; }
        }

        public double Width
        {
            get { return width; }
            set { width = value >= 0 ? value : 0; }
        } 

        public double this[char symbol]
        {  
            get {
                if (symbols.Contains(symbol))
                {
                    switch (symbol)
                    {
                        case 'w': return width;
                        case 'l': return length;
                        case 'x': return leftPoint.Coordinates[0];
                        case 'y': return leftPoint.Coordinates[1];
                         
                    }
                }
                return -1;
            }
            set
            {
                if (symbols.Contains(symbol) && value >=0)
                {
                    switch (symbol)
                    {
                        case 'w': width = value; break;
                        case 'l': length = value; break;
                        case 'x': leftPoint[0] = (int)value; break;
                        case 'y': leftPoint[1] = (int)value; break;
                    }
                }

            }
        }
        #endregion

        public static double Area(double width, double length) => length * width;

        public static IEnumerable<Rectangle> SortBy(List<Rectangle> list, 
                                                    CompareBy compare)
        {
            return list.OrderByDescending(rectangle => compare(rectangle.width, rectangle.length));
        }
        public override string ToString() => $"{R_ID}:" +
                                           $"W: {width}, L:{length}" +
                                           $"P:{leftPoint}";

    }
}
