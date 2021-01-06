using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public class ProgramHelper : ProgramConverter, IConvertible,
                                                   ICodeChecker
    {
        private string sourceCode;
        public ProgramHelper(string sourceCode)
        {
            this.sourceCode = sourceCode;
        }
 
        bool ICodeChecker.CodeCheckSyntax(string code2Check, string language)
        {
            Console.WriteLine($"{code2Check} {language}");
            return true;
        } 

        string IConvertible.ConvertToVB2015(string sourceCode)
        {
            return $"{sourceCode} converted to VB2015";
        }
        string IConvertible.ConvertToCSharp(string sourceCode)
        {
            Console.WriteLine("ProgramHelper: ConvertToCSharp");
            return "ProgramHelper: ConvertToCSharp";
             
        }


    }
}