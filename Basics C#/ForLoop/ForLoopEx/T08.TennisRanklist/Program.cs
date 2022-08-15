using System;

namespace T08.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int pointsAtStart = int.Parse(Console.ReadLine());
            int points = pointsAtStart;
            double tournamentsWon = 0.00;

            for (int i = 1; i <= tournaments; i++)
            {
                string roundReach = Console.ReadLine();
                if(roundReach == "SF")
                {
                    points += 720;
                }
                if(roundReach == "F")
                {
                    points += 1200;
                }
                if (roundReach == "W")
                {
                    points += 2000;
                    tournamentsWon++;
                }
            }
            double average = ((points - pointsAtStart) / tournaments);
            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {average}");
            double porcentWonTournaments = (tournamentsWon / tournaments) * 100;
            Console.WriteLine($"{porcentWonTournaments:F2}%");
        }
    }
}
