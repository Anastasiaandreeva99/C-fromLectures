using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Account
    {
        
        #region Fields
        private decimal annualInterestRate; // propfull snippet 4 full property
        private decimal balance;
        private DateTime dateCreated;
        private string owner;


        #endregion

        #region Constructors
        /// <summary>
        /// General purpose contructor
        /// </summary>
        public Account(decimal annualInterestRate,
                       decimal balance,
                        DateTime dateCreated,
                        string id)
        {
            AnnualInterestRate = annualInterestRate;
            Balance = balance;
            DateCreated = dateCreated;
            Id = id;
        }
        // Default constructor
        public Account()
        {
            AnnualInterestRate = 0.1m;
            Balance = 0;
            DateCreated = DateTime.Now;
            Id = "123456";
        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        public Account(Account account)
        {

            AnnualInterestRate = account.annualInterestRate;
            Balance = account.balance;
            DateCreated = account.dateCreated;
            Id = account.Id;
        }

        #endregion

        #region Properties
        public string Id { get; set; } 
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value != null ? value : DateTime.Now; }
        }
        public decimal Balance
        {
            get { return balance; }
            set { balance = value >= 0 ? value : 0m; }
        }

        public decimal AnnualInterestRate
        {
            get { return annualInterestRate; }
            set { annualInterestRate = value > 0 ? value : 0.1M; }
        }
        
        public string Owner
        {
            get => default;
            set { }
        }
        #endregion

        public void Deposit(decimal amount2Deposit)
        {
            if (amount2Deposit>0)
            {
                balance = balance * (1 + annualInterestRate); //add interest rate
                balance += amount2Deposit;      // add new deposit amount
                Console.WriteLine($"{amount2Deposit:C} deposited to account with id:{Id}");
            }
        }

        public void Credit(decimal amount2Credit)
        {
            if (amount2Credit>0 && balance >=amount2Credit)
            {
                balance -= amount2Credit;
                Console.WriteLine($"{amount2Credit:C} credited to account with id:{Id}");
            }
        }

        public override string ToString() => $"Accout: Id{Id}\nBalance:{balance:C}\n"+
                                             $"Date created: {DateCreated}";
         
    }
}
