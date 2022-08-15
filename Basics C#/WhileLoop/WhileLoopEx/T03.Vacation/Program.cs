using System;

namespace T03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //needed money 
            //balance 
            //spend OR save - anytimes
            //sum to spend OR save 

            //if(5 days spend ONLY):
            //"You can't save the money."
            //"{Общ брой изминали дни}"
            //if(neededMoney <= balance
            //"You saved the money for {общ брой изминали дни} days."

            double neededMoney = double.Parse(Console.ReadLine());
            double balance = double.Parse(Console.ReadLine());
            int daysSpend = 0;
            int days = 0;
            bool haveMoney = true;

            while(neededMoney > balance)
            {
                haveMoney = true;
                string spendORsave = Console.ReadLine();
                double sumToSpendORSave = double.Parse(Console.ReadLine());
                if(spendORsave == "spend")
                {
                    balance -= sumToSpendORSave;
                    daysSpend++;
                    if(balance <= 0)
                    {
                        balance = 0;
                    }
                    if(daysSpend == 5)
                    {
                        days++;
                        haveMoney = false;
                        break;
                    }
                }
                if(spendORsave == "save")
                {
                    daysSpend = 0;
                    balance += sumToSpendORSave;
                }
                days++;
            }

            if(haveMoney)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
            else
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine(days);
            }
        }
    }
}
