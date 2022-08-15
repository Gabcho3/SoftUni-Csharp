using System;

namespace T01.Tennis_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceRacket = double.Parse(Console.ReadLine());
            int rackets = int.Parse(Console.ReadLine());
            int shoes = int.Parse(Console.ReadLine());

            double priceRackets = priceRacket * rackets;
            double priceShoes = (priceRacket * 1.0 / 6.0) * shoes;
            double others = (priceRackets + priceShoes) * 0.20;
            double total = priceRackets + priceShoes + others;

            double djokovic = total * 1.0 / 8.0;
            double sponsors = total - djokovic;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(djokovic)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(sponsors)}");
        }
    }
}
