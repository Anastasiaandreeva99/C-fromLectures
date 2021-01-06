using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public delegate bool Greater(Comparable o1, Comparable o2);
    public struct Point: Comparable
    {
        public double X{ get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        private static string[] coords = { "x", "y", "z" };
        public Point(double x, double y, double z) 
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double this[string index]
        {
            get
            {
                switch (index)
                {
                    case "x":
                    case "X": return X;
                    case "y":
                    case "Y": return Y;
                    case "z":
                    case "Z": return Z;
                    default:
                        throw new InvalidOperationException();
                }
            }
            set {
                /* set the specified index to value here */
                switch (index)
                {
                    case "x":
                    case "X":  X= value; break;
                    case "y":
                    case "Y":  Y = value; break;
                    case "z":
                    case "Z":  Z = value; break;
                    default:
                        throw new InvalidOperationException();
                }

            }
        }


        public override string ToString() =>  $"[{this["x"]:F2}, " +
                                              $"{this["y"]:F2}," +
                                              $"{this["z"]:F2}]";
        #region Equals methods and operators
 
        
       
        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y &&
                   Z == point.Z;
        }

        public override int GetHashCode()
        {
            int hashCode = -307843816;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }

        double Comparable.SizeOf()
        {
            return Math.Abs(X + Y + Z);
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }
        #endregion
    }
}
