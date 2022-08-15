using System;

namespace T02.ReportSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int moneyNeeded = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int prices = 0;

            int sum = 0;
            double sumCash = 0;
            double sumCard = 0;
            int timesCounter = 1;
            int cashCounter = 0;
            int cardCounter = 0;
            bool failed = true;

            while (input != "End")
            {
                prices = int.Parse(input);
                sum += prices;
                if (timesCounter % 2 == 0)
                {

                    if (prices < 10)
                    {
                        sum -= prices;
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        cardCounter++;
                        Console.WriteLine("Product sold!"); 
                        sumCard += prices;
                    }
                }
                else
                {
                    if (prices > 100)
                    {
                        sum -= prices;
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        cashCounter++;
                        Console.WriteLine("Product sold!"); 
                        sumCash += prices;
                    }
                }
                if (sum >= moneyNeeded)
                {
                    failed = false;
                    break;
                }
                timesCounter++;
                input = Console.ReadLine();
            }
            double averageCash = sumCash / cashCounter;
            double averageCard = sumCard / cardCounter;
            if (failed)
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
            else
            {
                Console.WriteLine($"Average CS: {averageCash:f2}");
                Console.WriteLine($"Average CC: {averageCard:f2}");
            }
        }
    }
}
