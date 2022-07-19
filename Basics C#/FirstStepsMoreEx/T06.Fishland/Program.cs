using System;

namespace T06.Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceMackerel = double.Parse(Console.ReadLine());
            double priceSprinkle = double.Parse(Console.ReadLine());
            double kgBonito = double.Parse(Console.ReadLine());
            double kgSafrid = double.Parse(Console.ReadLine());
            double kgMussels = double.Parse(Console.ReadLine());

            double priceBonito = kgBonito * (priceMackerel + (priceMackerel * 0.60));
            double priceSafrid = kgSafrid * (priceSprinkle + (priceSprinkle * 0.80));
            double priceMussels = kgMussels * 7.50;
            double total = priceBonito + priceSafrid + priceMussels;
            Console.WriteLine($"{total:F2}");

        }
    }
}
