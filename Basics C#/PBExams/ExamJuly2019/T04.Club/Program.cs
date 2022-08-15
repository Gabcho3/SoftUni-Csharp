using System;

namespace Т04.Club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double wantedPrice = double.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            double priceForOneCoctail = 0;
            double total = 0;
            bool enoughMoney = false;
            while(name != "Party!")
            {
                int coctails = int.Parse(Console.ReadLine());
                int length = name.Length;
                priceForOneCoctail += coctails * length;
                if (priceForOneCoctail % 2 != 0) priceForOneCoctail -= priceForOneCoctail * 0.25;
                total += priceForOneCoctail;
                priceForOneCoctail = 0;
                if (wantedPrice <= total)
                {
                    enoughMoney = true; 
                    break;
                }
                name = Console.ReadLine();
            }
            if(name == "Party!") Console.WriteLine($"We need {wantedPrice - total:f2} leva more.");
            if (enoughMoney) Console.WriteLine($"Target acquired.");
            Console.WriteLine($"Club income - {total:f2} leva.");
        }
    }
}
