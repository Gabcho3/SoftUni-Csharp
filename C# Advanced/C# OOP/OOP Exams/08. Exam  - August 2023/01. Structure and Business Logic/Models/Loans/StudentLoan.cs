using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models.Loans
{
    public class StudentLoan : Loan
    {
        private const int interestRate = 1;
        private const double amount = 10_000;

        public StudentLoan() 
            : base(interestRate, amount){}

    }
}
