using System;

namespace T06.BasketballTournament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int games = int.Parse(Console.ReadLine());

            double wins = 0;
            double loses = 0;
            int totalgames = 0;

            while(true)
            {
                totalgames += games;
                for(int game = 1; game <= games; game++)
                {
                    int team1 = int.Parse(Console.ReadLine()); //points of Desi's team
                    int team2 = int.Parse(Console.ReadLine()); //points of opponent team
                    if (team1 > team2) { Console.WriteLine($"Game {game} of tournament {name}: win with {team1 - team2} points."); wins++; }
                    if(team1 < team2) { Console.WriteLine($"Game {game} of tournament {name}: lost with {team2 - team1} points."); loses++; }
                }
                name = Console.ReadLine();
                if(name == "End of tournaments") { break;}
                games = int.Parse(Console.ReadLine());
            }
            double percentWins = wins / totalgames * 100;
            Console.WriteLine($"{percentWins:f2}% matches win");
            double percentLoses = loses / totalgames * 100;
            Console.WriteLine($"{percentLoses:f2}% matches lost");
        }
    }
}
