using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public struct Vector : Comparable
    {
        public Point SPoint { get; set; }
        public Point EPoint { get; set; }

        public Vector(Point spoint, Point epoint)
        {
            SPoint = spoint;
            EPoint = epoint;    
        }

        public override string ToString() => $"V:{SPoint};{EPoint}";


        public override bool Equals(object obj)
        {
            return obj is Vector vector &&
                   EqualityComparer<Point>.Default.Equals(SPoint, vector.SPoint) &&
                   EqualityComparer<Point>.Default.Equals(EPoint, vector.EPoint);
        }

        public override int GetHashCode()
        {
            int hashCode = -655591894;
            hashCode = hashCode * -1521134295 + SPoint.GetHashCode();
            hashCode = hashCode * -1521134295 + EPoint.GetHashCode();
            return hashCode;
        }

        //public double SizeOf()
        //{
        //    return ((Comparable)SPoint).SizeOf();
        //}

        double Comparable.SizeOf()
        {
            double dx = SPoint.X - EPoint.X;
            double dy = SPoint.Y - EPoint.Y;
            double dz = SPoint.Z - EPoint.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public static bool operator ==(Vector left, Vector right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector left, Vector right)
        {
            return !(left == right);
        }
    }
}
