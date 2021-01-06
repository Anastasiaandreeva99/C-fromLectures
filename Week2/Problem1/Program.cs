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
            // local vars
            Account accountTest;
            Account account = new Account();
            decimal balance;
            decimal annualRate;

            // initialization
            Console.WriteLine(account);

            // input Account datamembers
            Console.Write("Enter balance: ");
            balance = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Annual rate: ");
            annualRate = decimal.Parse(Console.ReadLine());

            // Processing
            // create Account with custom data
            accountTest = new Account(annualRate, balance, DateTime.Now, "00001");
            Console.WriteLine(accountTest);
           
            Console.WriteLine("deposit 1000");
            accountTest.Deposit(1000m);
            Console.WriteLine(accountTest);
        }
    }
}
