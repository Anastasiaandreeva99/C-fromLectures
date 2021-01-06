using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public class ProgramConverter : IConvertible
    {
        string IConvertible.ConvertToCSharp(string sourceCode)
        {
            Console.WriteLine("ProgramConverter: ConvertToCSharp");
            return "ProgramConverter: ConvertToCSharp";
        }

        string IConvertible.ConvertToVB2015(string sourceCode)
        {
            Console.WriteLine("ProgramConverter: ConvertToVB2015");
            return "ProgramConverter: ConvertToVB2015";

        }
    }
}