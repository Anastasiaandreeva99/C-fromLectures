using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitwiseOps
{
    public class IntBits
    {
        private int intNumber;

        #region Constructors
        public IntBits(int value)
        {
            IntNumber = value;
        }
        public IntBits()
        {
            intNumber = 0;
        }
        #endregion

        #region Properties

        public byte this[byte index]
        {
            get { /* return the specified index here */ 
                if( index < 32)
                {
                    int mask = 1 << index;
                    return (intNumber & mask) == 0? (byte)0: (byte)1;
                }
                else
                throw new InvalidOperationException();
            }
            
            set
            { /* set the specified index to value here */
                if (index < 32 && (value <=1))
                {
                    intNumber = (value == 1)? intNumber | 1 << index :
                                             intNumber & (~(1 << index));
                }
                else
                    throw new InvalidOperationException();
            }
        }


        public int IntNumber
        {
            get { return intNumber; }
            set
            {
                intNumber =
                  value <= int.MaxValue && value >= int.MinValue ?
                          value : 0;
            }
        }
        #endregion
        public override string ToString() => Bits2String();
         
        private string Bits2String()
        {   
            int temp = intNumber;
            string output = "";
            int mask = 1 << 31;
            for (int i = 1; i <= 32; i++)
            {
                output += ((temp & mask) == 0)? "0": "1";
                temp <<= 1;
                if (i % 8 == 0 ) output += " ";
            }
            return output;
        }
    }
}
