using System;

namespace T01.OscarsCeremony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());
            double priceFigurines = rent - (rent * 0.30);
            double priceCatering = priceFigurines - (priceFigurines * 0.15);
            double priceVoice = priceCatering / 2;
            double total = rent + priceFigurines + priceCatering + priceVoice;
            Console.WriteLine($"{total:f2}");
        }
    }
}
