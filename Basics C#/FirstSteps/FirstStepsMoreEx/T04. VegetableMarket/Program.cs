using System;

namespace T04._VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceVegatable = double.Parse(Console.ReadLine());
            double priceFruit  = double.Parse(Console.ReadLine());
            double kgVegatables = double.Parse(Console.ReadLine());
            double kgFruits = double.Parse(Console.ReadLine());

            double totalVegatable = priceVegatable * kgVegatables;
            double prfr = priceFruit * kgFruits;

            double preuro = (priceVegatable + priceFruit) / 1.94;
            Console.WriteLine($"{preuro:F2}");
        }
    }
}
