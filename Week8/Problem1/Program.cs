using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramHelper ph = new ProgramHelper("code");
            ProgramConverter pc = new ProgramConverter();
            
            IConvertible iconv = ph;
            IConvertible iconv1 = pc;
            iconv.ConvertToCSharp("CS");
            iconv1.ConvertToCSharp("CS");
            Console.WriteLine("switch");
            switch (iconv)
            {
                case ICodeChecker value2: value2.ConvertToCSharp("code");
                                          break;
                case IConvertible value1: value1.ConvertToCSharp("code");
                                          break;
            }
             

        }
    }
}
