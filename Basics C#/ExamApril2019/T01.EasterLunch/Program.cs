using System;

namespace T01.EasterLunch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cakes = int.Parse(Console.ReadLine());
            int eggs = int.Parse(Console.ReadLine());
            int cookies = int.Parse(Console.ReadLine());

            double priceCakes = cakes * 3.20;
            double priceEggs = eggs * 4.35;
            double pricePaint = eggs * 12 * 0.15;
            double priceCookies = cookies * 5.40;
            double sum = priceCakes + priceEggs + pricePaint + priceCookies;
            Console.WriteLine($"{sum:f2}");
        }
    }
}
