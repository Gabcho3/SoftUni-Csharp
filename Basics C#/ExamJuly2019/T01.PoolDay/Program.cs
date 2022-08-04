using System;

namespace Т01.PoolDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double priceEntrance = double.Parse(Console.ReadLine());
            double priceLounge = double.Parse(Console.ReadLine());
            double priceUmprella = double.Parse(Console.ReadLine());

            double totalPriceEntrance = people * priceEntrance;
            double totalPriceLounge = Math.Ceiling(people * 0.75) * priceLounge;
            double totalPriceUmprella = Math.Ceiling(people * 0.50) * priceUmprella;
            double totalPrice = totalPriceEntrance + totalPriceLounge + totalPriceUmprella;
            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
