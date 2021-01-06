using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Point
    {
        private int[] coordinates;

        #region Constructors
        public Point(int[] coordinates)
        {
            Coordinates = coordinates;
        }
        public Point(Point point) : this(point.coordinates)
        {

        }
        public Point() : this(new int[2])
        {

        }
        #endregion

        #region Properties

        public int this[byte index]
        {
            get
            {
                if (index < 2)
                    return coordinates[index];
                else return -1;
            }
            set { /* set the specified index to value here */
                if (index < 2)
                     coordinates[index] = value;   
            }
        }
        public int[] Coordinates
        {
            get
            {
                return
                    new int[] { coordinates[0], coordinates[1] };
            }
            set
            {
                //if(value!= null && value.Length == 2)
                //{
                //    coordinates = new int[value.Length];
                //    for (int i = 0; i < value.Length; i++)
                //    {
                //        coordinates[i] = value[i];
                //    }
                //}
                coordinates = value != null && value.Length == 2 ?
                                 new int[] { value[0], value[1] } :
                                  new int[2];
            }
        }
        #endregion

        public override string ToString()
              => $"[{coordinates[0]}, {coordinates[1]}]";

    }
}
