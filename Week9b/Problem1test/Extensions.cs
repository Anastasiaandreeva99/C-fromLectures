using Problem1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1test
{
    /// <summary>
    /// Class with Extension methods
    /// </summary>
    public static class Extensions
    {
        public static List<int> Filter(this Vector vector,Predicate<int> test)
        {
            List<int> list = new List<int>();
            list = vector.P.Where(element => test(element)).ToList();
            return list;
        }

        public static Vector Map(this Vector vector, Func<int, int> map)
        {
            int  start = vector.I1;
            int[] data = vector.P;
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = map(data[i]);
            }
            return   new Vector(data,start);
        }
    }
}
