using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models.Banks
{
    public abstract class Bank : IBank
    {
        private string name;
        private List<ILoan> loans = new();
        private List<IClient> clients = new();

        protected Bank(string name,  int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public int Capacity { get; }

        public IReadOnlyCollection<ILoan> Loans => loans;

        public IReadOnlyCollection<IClient> Clients => clients;

        public double SumRates() => Loans.Select(l => l.InterestRate).Sum();

        public void AddClient(IClient Client)
        {
            if (clients.Count >= Capacity)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }

            clients.Add(Client);
        }

        public void RemoveClient(IClient client) => clients.Remove(client);

        public void AddLoan(ILoan loan) => loans.Add(loan);

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");

            string clientsOutput = clients.Count > 0
                ? string.Join(", ", clients.Select(c => c.Name).ToArray()) 
                : "none";

            sb.AppendLine("Clients: " +  clientsOutput);

            double sumOfRates = loans.Select(l => l.InterestRate).Sum();
            sb.AppendLine($"Loans: {loans.Count}, Sum of Rates: {sumOfRates}");

            return sb.ToString().Trim();
        }
    }
}
