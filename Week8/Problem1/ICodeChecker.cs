using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public interface ICodeChecker : IConvertible
    {
        bool CodeCheckSyntax(string code2Check, string language);
    }
}