using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Problem1
{
    /// <summary>
    /// Part of Geometry.DLL
    /// </summary>
    public class Point
    {
        #region Data members
        private int[] coordinates;

        public int[] Coordinates
        { // single responsibiligty principle
            get
            {
                int[] temp = new int[coordinates.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = coordinates[i];
                }
                return temp;//int[] temp= {coordinates[0], coordinates[1]}
            }

            set
            {
                if (value != null && value.Length == 2)
                {
                    coordinates = new int[] { value[0], value[1] };
                }
                else
                {
                    coordinates = new int[] { 0, 0 };
                }
            }
        }

        public int this[int index]
        {
            get
            { if(index >=0 && index <= 1)
                {
                    return coordinates[index];
                }
                return -1;
            }
            set
            {
                if (index >= 0 && index <= 1 && value >=0)
                {
                    switch (index)
                    {
                        case 0:
                            coordinates[0] = value;
                            break;
                        case 1:
                            coordinates[1] = value;
                            break;
                    }
                     
                }
            }
        }
        #endregion

        #region Constructors
        public Point(int[] coordinates)
        {
            Coordinates = coordinates;
        }
        public Point() : this(new int[] { 0, 0 })
        {

        }
        public Point(Point point) : this(point.coordinates)
        {

        } 
        #endregion

        public override string ToString() => $"[{coordinates[0]}, {coordinates[1]}]";
        }
    }

