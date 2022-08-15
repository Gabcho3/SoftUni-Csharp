using System;

namespace T02.EasterParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            double couvert = double.Parse(Console.ReadLine());
            double bujet = double.Parse(Console.ReadLine());

            if (guests >= 10 && guests <= 15) couvert -= couvert * 0.15;
            if (guests >= 16 && guests <= 20) couvert -= couvert * 0.20;
            if (guests > 20) couvert -= couvert * 0.25;
            double priceCake = bujet * 0.10;
            double total = couvert * guests + priceCake;
            if (total > bujet) Console.WriteLine($"No party! {total - bujet:f2} leva needed.");
            else Console.WriteLine($"It is party time! {bujet - total:f2} leva left.");

        }
    }
}
