using System;

namespace T01.EasterBakery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceFor1KgFlour = double.Parse(Console.ReadLine());
            double kgFlour = double.Parse(Console.ReadLine());
            double kgSugar = double.Parse(Console.ReadLine());
            int eggs = int.Parse(Console.ReadLine());
            int yeast = int.Parse(Console.ReadLine());

            double priceFlour = priceFor1KgFlour * kgFlour;
            double priceFor1KgSugar = priceFor1KgFlour - (priceFor1KgFlour * 0.25);
            double priceSugar = priceFor1KgSugar * kgSugar;
            double priceEggs = (priceFor1KgFlour + (priceFor1KgFlour * 0.10)) * eggs; 
            double priceYeast = (priceFor1KgSugar - (priceFor1KgSugar * 0.80)) * yeast;

            double sum = priceEggs + priceFlour + priceYeast + priceSugar;
            Console.WriteLine($"{sum:f2}");
        }
    }
}
