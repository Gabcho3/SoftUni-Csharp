using System;

namespace T04.EasterShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eggs = int.Parse(Console.ReadLine());
            string activity = Console.ReadLine();
            int sold = 0;
            int have = 0;
            bool noEggs = false;

            while (activity != "Close")
            {
                int buyOrFill = int.Parse(Console.ReadLine());
                if (activity == "Buy") { have = eggs;  eggs -= buyOrFill; sold += buyOrFill; }
                if (activity == "Fill") { eggs += buyOrFill; }
                if (eggs < 0)
                {
                    noEggs = true;
                    break;
                }
                activity = Console.ReadLine();
            }
            if(noEggs)
            {
                Console.WriteLine("Not enough eggs in store!");
                Console.WriteLine($"You can buy only {have}.");
                return;
            }
            Console.WriteLine("Store is closed!");
            Console.WriteLine($"{sold} eggs sold.");
        }
    }
}
