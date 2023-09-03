using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models.Loans
{
    public class MortgageLoan : Loan
    {
        private const int interestRate = 3;
        private const double amount = 50_000;

        public MortgageLoan()
            : base(interestRate, amount) { }
    }
}
