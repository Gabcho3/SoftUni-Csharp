using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BankLoan.Core.Contracts;
using BankLoan.Models.Banks;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private LoanRepository loans = new();
        private BankRepository banks = new();

        private List<string> bankTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "BankLoan.Models.Banks")
            .Select(t => t.Name)
            .ToList();

        private List<string> loanTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "BankLoan.Models.Loans")
            .Select(t => t.Name)
            .ToList();

        private List<string> clientTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "BankLoan.Models.Clients")
            .Select(t => t.Name)
            .ToList();

        public string AddBank(string bankTypeName, string name)
        {
            if (!bankTypes.Contains(bankTypeName))
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == bankTypeName);
            IBank bank = Activator.CreateInstance(type, new object[] { name }) as IBank;
            banks.AddModel(bank);

            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddLoan(string loanTypeName)
        {
            if (!loanTypes.Contains(loanTypeName))
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == loanTypeName);
            ILoan loan = Activator.CreateInstance(type) as ILoan;
            loans.AddModel(loan);

            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = loans.FirstModel(loanTypeName);
            IBank bank = banks.FirstModel(bankName);

            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }
            loans.RemoveModel(loan);
            bank.AddLoan(loan);

            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if (!clientTypes.Contains(clientTypeName))
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            IBank bank = banks.Models.FirstOrDefault(b => b.Name == bankName);
            string bankTypeName = bank.GetType().Name;

            if ((clientTypeName == "Student" && bankTypeName != "BranchBank")
               || (clientTypeName == "Adult" && bankTypeName != "CentralBank"))
            {
                return OutputMessages.UnsuitableBank;
            }

            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == clientTypeName);
            IClient client = Activator.CreateInstance(type, new object[] {clientName, id, income}) as IClient;
            bank.AddClient(client);

            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.FirstModel(bankName);
            double funds = bank.Clients.Select(c => c.Income).Sum() + bank.Loans.Select(l => l.Amount).Sum();

            return $"The funds of bank {bankName} are {funds:f2}.";
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().Trim();
        }
    }
}
