using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;
using BankLoan.Models.Loans;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private readonly List<ILoan> models = new ();

        public IReadOnlyCollection<ILoan> Models => models;

        public void AddModel(ILoan model) => models.Add(model);

        public bool RemoveModel(ILoan model) => models.Remove(model);

        public ILoan FirstModel(string name) => models.FirstOrDefault(l => l.GetType().Name == name);
    }
}
