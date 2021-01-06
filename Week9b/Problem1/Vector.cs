using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Vector : ISelectable, IComparable
    {
        private int[] p;
        private int i1;

        #region Constructors

        public Vector(int[] p, int i1)
        {
            P = p;
            this.i1 = i1;
        }
        public Vector() : this(new int[1], 0)
        {

        }
        public Vector(Vector vector) : this(vector.p, vector.i1)
        {

        }

        #endregion

        #region Properties
        public int[] P
        {
            get
            {
                int[] copy = new int[p.Length];
                Array.Copy(p, copy, p.Length);
                return copy;
            }
            set
            {
                if (value != null)
                {
                    p = new int[value.Length];
                    Array.Copy(value, p, value.Length);
                }
                else
                    throw new ArgumentNullException($"{(GetType())}:" +
                                                    $"Set invalid array value.");
            }
        }

        public int I1
        {
            get
            {
                return i1;
            }
            set
            {
                i1 = value;
            }
        }

        /// <summary>
        /// Use user defined index i1 to access the array elements
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        int ISelectable.this[int index]
        {
            get
            {
                if (index >= i1 && index < i1 + p.Length)
                {
                    return p[index - i1];
                }
                else
                    throw new ArgumentOutOfRangeException($"{(GetType())}:Indexer wrong index on read");
            }

            set
            {
                if (index >= i1 && index < i1 + p.Length)
                {
                    p[index - i1] = value;
                }
                else
                    throw new ArgumentOutOfRangeException($"{(GetType())}:Indexer wrong index on write");
            }

        }

        #endregion

        public override string ToString() =>
               $"Vector:{(string.Join(", ", P))}, index:{i1}";


        #region Comparison methods
        public int CompareTo(object obj)
        {
            if (obj is Vector vector)
            {
                if (this.Equals(vector)) return 0; // this is equal to obj
                else
                    return i1 - vector.i1;
            }
            else
            {
                return 1; // this is greater than null
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector vector)
            {
                if (p.Length == vector.p.Length)
                {
                    for (int i = 0; i < p.Length; i++)
                    {
                        if (p[i] != vector.p[i]) return false;
                    }
                    if (i1 == vector.i1) return true;
                    else // vectors of different indexatoin
                        return false;
                }
                else
                    return false;// arrays of different length
            }
            else
                return false; // obj is null or not a Vector

        }

        public override int GetHashCode()
        {
            int hashCode = 1998138614;
            hashCode *= -1521134295;
            for (int i = 0; i < p.Length; i++)
            {
                hashCode += p[i].GetHashCode();
            }
            hashCode = hashCode * -1521134295 + i1.GetHashCode();
            return hashCode;
        }
        public static bool operator ==(Vector left, Vector right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Vector left, Vector right)
        {
            return !(left == right);
        }
        #endregion

        /// <summary>
        /// Implict conversion of int[] to Vector
        /// </summary>
        /// <param name="array"></param>
        public static implicit operator Vector(int[] array)
        {
            return new Vector(array, 0);
        }

        /// <summary>
        /// Explicit conversion from Vector to int[] 
        /// </summary>
        /// <param name="array"></param>
        public static explicit operator int[](Vector vector)
        {
            return vector.P;
        }
    }
}
