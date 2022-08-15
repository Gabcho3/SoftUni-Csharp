using System;

namespace T01.FruitMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceBerryKg = double.Parse(Console.ReadLine());
            double banansKg = double.Parse(Console.ReadLine());
            double orangesKg = double.Parse(Console.ReadLine());
            double raspberryKg = double.Parse(Console.ReadLine());
            double berriesKg = double.Parse(Console.ReadLine());

            double priceRasberyKg = priceBerryKg / 2;
            double priceRasbery = priceRasberyKg * raspberryKg;
            double priceOrange = (priceRasberyKg - (priceRasberyKg * 0.40)) * orangesKg;
            double priceBanana = (priceRasberyKg - (priceRasberyKg * 0.80)) * banansKg;
            double priceBerry = berriesKg * priceBerryKg;
            double total = priceRasbery + priceOrange + priceBanana + priceBerry;
            Console.WriteLine($"{total:f2}");
        }
    }
}
