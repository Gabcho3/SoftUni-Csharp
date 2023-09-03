using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Banks;
using BankLoan.Models.Contracts;
using BankLoan.Models.Loans;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private readonly List<IBank> models = new();

        public IReadOnlyCollection<IBank> Models => models;

        public void AddModel(IBank bank) => models.Add(bank);

        public bool RemoveModel(IBank bank) => models.Remove(bank);

        public IBank FirstModel(string name) => models.FirstOrDefault(b => b.Name == name);
    }
}
