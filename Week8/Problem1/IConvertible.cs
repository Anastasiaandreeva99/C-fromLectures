using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public interface IConvertible
    {
        string ConvertToCSharp(string sourceCode);
        string ConvertToVB2015(string sourceCode);
    }
}