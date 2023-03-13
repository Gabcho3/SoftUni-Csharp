using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] accountsData = Console.ReadLine().Split(',');
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            foreach (var accountData in accountsData)
            {
                int accountNumber = int.Parse(accountData.Split('-')[0]);
                double accountBalance = double.Parse(accountData.Split("-")[1]);
                accounts.Add(accountNumber, accountBalance);
            }

            while (true)
            {
                bool hasException = false;

                string[] command = Console.ReadLine().Split();
                string cmd = command[0];

                if(cmd == "End")
                {
                    return;
                }

                int number = int.Parse(command[1]);
                double sum = double.Parse(command[2]);

                try
                {
                    switch (cmd)
                    {
                        case "Deposit":
                            Deposit(accounts, number, sum);
                            break;

                        case "Withdraw":
                            Withdraw(accounts, number, sum);
                            break;

                        default:
                            throw new ArgumentException("Invalid command!");
                    }
                }
                catch(KeyNotFoundException)
                {
                    Console.WriteLine("Invalid account!");
                    hasException = true;
                }
                catch(InvalidOperationException invEx)
                {
                    Console.WriteLine(invEx.Message);
                    hasException = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    hasException = true;
                }
                finally
                {
                    if (!hasException)
                    {
                        Console.WriteLine($"Account {number} has new balance: {accounts[number]:f2}");
                    }

                    Console.WriteLine("Enter another command");
                }
            }
        }

        private static void Withdraw(Dictionary<int, double> accounts, int number, double sum)
        {
            if (accounts[number] < sum)
            {
                throw new InvalidOperationException("Insufficient balance!");
            }

            accounts[number] -= sum;
        }

        private static void Deposit(Dictionary<int, double> accounts, int number, double sum)
            => accounts[number] += sum;
    }
}
