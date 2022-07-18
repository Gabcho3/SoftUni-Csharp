using System;

namespace T05.PCGameShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int soldGames = int.Parse(Console.ReadLine());
            double p1 = 0; //hearthstone
            double p2 = 0; //fortnite
            double p3 = 0; //overwatch
            double p4 = 0; //others

            for(int game = 1; game <= soldGames; game++)
            {
                string name = Console.ReadLine();
                switch(name)
                {
                    case "Hearthstone": p1++; break;
                    case "Fornite": p2++; break;
                    case "Overwatch": p3++; break;
                    default: p4++; break;
                }
            }
            double percent1 = p1 / soldGames * 100;
            Console.WriteLine($"Hearthstone - {percent1:f2}%");
            double percent2 = p2 / soldGames * 100;
            Console.WriteLine($"Fornite - {percent2:f2}%");
            double percent3 = p3 / soldGames * 100;
            Console.WriteLine($"Overwatch - {percent3:f2}%");
            double percent4 = p4 / soldGames * 100;
            Console.WriteLine($"Others - {percent4:f2}%");
        }
    }
}
