using System;

namespace T01.MatchTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            double transport = 0.00;

            switch (category)
            {
                case "Normal":

                    if (people >= 1 & people <= 4)
                    {
                        transport = bujet - (bujet * 0.75);
                    }
                    if (people >= 5 & people <= 9)
                    {
                        transport = bujet - (bujet * 0.60);
                    }
                    if (people >= 10 & people <= 24)
                    {
                        transport = bujet - (bujet * 0.50);
                    }
                    if (people >= 25 & people <= 49)
                    {
                        transport = bujet - (bujet * 0.40);
                    }
                    if (people >= 50)
                    {
                        transport = bujet - (bujet * 0.25);
                    }

                    double ticket = 249.99 * people;
                    if (ticket <= transport)
                    {
                        Console.WriteLine($"Yes! You have {-(ticket - transport):F2} leva left.");
                    }
                    if (ticket > transport)
                    {
                        Console.WriteLine($"Not enough money! You need {-(transport - ticket):F2} leva.");
                    }

                    break;
            }

            switch (category)
            {
                case "VIP":

                    if (people >= 1 & people <= 4)
                    {
                        transport = bujet - (bujet * 0.75);
                    }
                    if (people >= 5 & people <= 9)
                    {
                        transport = bujet - (bujet * 0.60);
                    }
                    if (people >= 10 & people <= 24)
                    {
                        transport = bujet - (bujet * 0.50);
                    }
                    if (people >= 25 & people <= 49)
                    {
                        transport = bujet - (bujet * 0.40);
                    }
                    if (people >= 50)
                    {
                        transport = bujet - (bujet * 0.25);
                    }

                    double ticket = 499.99 * people;
                    if (ticket <= transport)
                    {
                        Console.WriteLine($"Yes! You have {-(ticket - transport):F2} leva left.");
                    }
                    if (ticket > transport)
                    {
                        Console.WriteLine($"Not enough money! You need {-(transport - ticket):F2} leva.");
                    }

                    break;
            }
        }
    }
}
