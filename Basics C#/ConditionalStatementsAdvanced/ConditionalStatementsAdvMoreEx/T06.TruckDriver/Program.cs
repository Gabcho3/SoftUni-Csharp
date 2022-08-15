using System;

namespace Т06.TruckDriver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double km = double.Parse(Console.ReadLine());
            double price;
            double salary;

            if(km <= 5000)
            {
                if(season == "Spring" || season == "Autumn")
                {
                    price = km * 0.75 * 4;
                    salary = price - (price * 0.10);
                    Console.WriteLine($"{salary:F2}");
                }
                if(season == "Summer")
                {
                    price = km * 0.90 * 4;
                    salary = price - (price * 0.10);
                    Console.WriteLine($"{salary:F2}");
                }
                if(season == "Winter")
                {
                    price = km * 1.05 * 4;
                    salary = price - (price * 0.10);
                    Console.WriteLine($"{salary:F2}");
                }
            }

            if(km > 5000 & km <= 10000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    price = km * 0.95 * 4;
                    salary = price - (price * 0.10);
                    Console.WriteLine($"{salary:F2}");
                }
                if (season == "Summer")
                {
                    price = km * 1.10 * 4;
                    salary = price - (price * 0.10);
                    Console.WriteLine($"{salary:F2}");
                }
                if (season == "Winter")
                {
                    price = km * 1.25 * 4;
                    salary = price - (price * 0.10);
                    Console.WriteLine($"{salary:F2}");
                }
            }

            if(km > 10000 & km <= 20000)
            {
                price = km * 1.45 * 4;
                salary = price - (price * 0.10);
                Console.WriteLine($"{salary:F2}");
            }
        }
    }
}
