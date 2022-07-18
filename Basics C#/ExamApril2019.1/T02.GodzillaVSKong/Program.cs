using System;

namespace T02.GodzillaVSKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            int  extras = int.Parse(Console.ReadLine());
            double priceClothes = double.Parse(Console.ReadLine());
            double priceDecor = bujet * 0.10;
            if (extras > 150) priceClothes -= priceClothes * 0.10;
            double priceForExtras = priceClothes * extras;
            double total = priceDecor + priceForExtras;
            if (total > bujet)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {total - bujet:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {bujet - total:f2} leva left.");
            }
        }
    }
}
