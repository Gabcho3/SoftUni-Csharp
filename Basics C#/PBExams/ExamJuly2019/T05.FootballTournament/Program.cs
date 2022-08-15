using System;

namespace T05.FootballTournament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int matches = int.Parse(Console.ReadLine());
            if (matches == 0)
            {
                Console.WriteLine($"{name} hasn't played any games during this season."); 
                return;
            }
            double wins = 0;
            int draws = 0;
            int loses = 0;
            int points = 0;
            for(int match = 1; match <= matches; match++)
            {
                string result = Console.ReadLine();

                if (result == "W")
                {
                    wins++; points += 3; 
                    continue;
                }
                if (result == "D")
                {
                    draws++; points += 1; 
                    continue;
                }
                 if(result == "L") loses++; 
                
            }
            Console.WriteLine($"{name} has won {points} points during this season.");
            Console.WriteLine("Total stats:");
            Console.WriteLine($"## W: {wins}");
            Console.WriteLine($"## D: {draws}");
            Console.WriteLine($"## L: {loses}");
            double winRate = wins / matches * 100;
            Console.WriteLine($"Win rate: {winRate:f2}%");
        }
    }
}
