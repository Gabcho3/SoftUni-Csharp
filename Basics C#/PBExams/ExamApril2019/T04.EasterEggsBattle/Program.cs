using System;

namespace T04.EasterEggsBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eggs1 = int.Parse(Console.ReadLine());
            int eggs2 = int.Parse(Console.ReadLine());
            bool noEggs1 = false;
            bool noEggs2 = false;
            string winner = Console.ReadLine();
            while (winner != "End")
            {
                if (winner == "one") eggs2--;
                if (winner == "two") eggs1--;
                if(eggs1 == 0)
                {
                    noEggs1 = true;
                    break;
                }
                if(eggs2 == 0)
                {
                    noEggs2 = true;
                    break;
                }
                winner = Console.ReadLine();
            }
            if(noEggs1)
            {
                Console.WriteLine($"Player one is out of eggs. Player two has {eggs2} eggs left.");
                return;
            }
            if(noEggs2)
            {
                Console.WriteLine($"Player two is out of eggs. Player one has {eggs1} eggs left.");
                return;
            }
            Console.WriteLine($"Player one has {eggs1} eggs left.");
            Console.WriteLine($"Player two has {eggs2} eggs left.");
        }
    }
}
