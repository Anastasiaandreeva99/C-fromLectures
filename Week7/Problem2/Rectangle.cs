using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Rectangle : Point
    {
        // Create unique ID for each Rectangle instance
        public readonly string ID;
        private static int cnt = 1;
        
        private Point lowerRightPoint;

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="upperLeftPoint"></param>
        /// <param name="lowerRightPoint"></param>
        public Rectangle(Point upperLeftPoint, Point lowerRightPoint)
           : base(upperLeftPoint)
        {
            LowerRightPoint = lowerRightPoint;
            ID = $"R{(cnt++):D4}";
        }

        public Rectangle(Rectangle rectangle)
            : this(rectangle.UpperLeftPoint, rectangle.lowerRightPoint)
        {

        }

        public Rectangle()
            : this(new Point(), new Point())
        {

        } 
        #endregion
        #region Properties

        public Point LowerRightPoint
        {
            get
            {
                return new Point(lowerRightPoint);
            }
            set
            {
                lowerRightPoint = value != null ?
                                  new Point(value)
                                  : new Point();
            }
        }

        public Point UpperLeftPoint
        {
            get
            {
                return new Point(Coordinates);
            }
            set
            {
                if (value != null)
                {
                    Coordinates = value.Coordinates;
                }
                else
                    Coordinates = new int[2];
            }
        }
        #endregion

        public double Area()
        {
            int deltaX= Math.Abs(UpperLeftPoint[0] - lowerRightPoint[0]);
            int deltaY = Math.Abs(UpperLeftPoint[1] - lowerRightPoint[1]);
            return deltaX * deltaY ;

        }
        public override string ToString()
            => $"{ID}: {base.ToString()}, {lowerRightPoint}";
         
    }
}
