using System;

namespace T07.FuelTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            double liters = double.Parse(Console.ReadLine());

            if (fuel == "Diesel")
            {
                if (liters < 25)
                {
                    Console.WriteLine($"Fill your tank with diesel!");
                }
                else
                {
                    Console.WriteLine($"You have enough diesel.");
                }
            }

            if (fuel == "Gas")
            {
                if (liters < 25)
                {
                    Console.WriteLine($"Fill your tank with gas!");
                }
                else
                {
                    Console.WriteLine($"You have enough gas.");
                }
            }

            if (fuel == "Gasoline")
            {
                if (liters < 25)
                {
                    Console.WriteLine($"Fill your tank with gasoline!");
                }
                else
                {
                    Console.WriteLine($"You have enough gasoline.");
                }
            }
            if(fuel != "Diesel" & fuel != "Gas" & fuel != "Gasoline")
            {
                Console.WriteLine("Invalid fuel!");
            }
        }
    }
}
