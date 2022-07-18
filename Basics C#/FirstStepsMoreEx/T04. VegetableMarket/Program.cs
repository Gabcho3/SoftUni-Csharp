using System;

namespace T04._VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double prkgve = double.Parse(Console.ReadLine());
            double prkgfr  = double.Parse(Console.ReadLine());
            double kgve = double.Parse(Console.ReadLine());
            double kgfr = double.Parse(Console.ReadLine());

            double prve = prkgve * kgve;
            double prfr = prkgfr * kgfr;

            double preuro = (prve + prfr) / 1.94;
            Console.WriteLine($"{preuro:F2}");
        }
    }
}
