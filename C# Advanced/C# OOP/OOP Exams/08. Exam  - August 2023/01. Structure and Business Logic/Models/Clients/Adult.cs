using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models.Clients
{
    public class Adult : Client
    {
        //This class will be only accepted in combination with CentralBank
        private const int interest = 4;
        public Adult(string name, string id, double income)
            : base(name, id, interest, income) { }

        public override void IncreaseInterest()
        {
            this.Interest += 2;
        }
    }
}
