using System;

namespace T05.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int points = int.Parse(Console.ReadLine());

            int startPoints = points;
            double wins = 0;
            
            for(int tournament = 1; tournament <= tournaments; tournament++)
            {
                string round = Console.ReadLine();
                if(round == "SF") { points += 720; }
                if(round == "F") { points += 1200; }
                if(round == "W") { points += 2000; wins++; }
            }
            Console.WriteLine($"Final points: {points}");
            int average = (points - startPoints) / tournaments;
            Console.WriteLine($"Average points: {average}");
            double percentWins = wins / tournaments * 100;
            Console.WriteLine($"{percentWins:f2}%");
        }
    }
}
