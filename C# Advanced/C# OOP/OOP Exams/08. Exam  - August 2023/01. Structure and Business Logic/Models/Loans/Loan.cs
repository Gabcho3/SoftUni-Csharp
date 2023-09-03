using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;

namespace BankLoan.Models.Loans
{
    public abstract class Loan : ILoan
    {
        protected Loan(int interestRate, double amount)
        {
            InterestRate = interestRate;
            Amount = amount;
        }

        public int InterestRate { get; }

        public double Amount { get; }
    }
}
