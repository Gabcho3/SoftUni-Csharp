using System;

namespace T06.TournamentOfChristmas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            double balance = 0;
            double balanceForDay = 0;
            int winsForDay = 0;
            int losesForDay = 0;
            int wins = 0;
            int loses = 0;
              
            for(int day = 1; day <= days; day++)
            {
                string sport = Console.ReadLine();
                while(sport != "Finish")
                {
                    string result = Console.ReadLine();
                    if(result == "win")
                    {
                        balanceForDay += 20;
                        winsForDay++;
                        wins++;
                    }
                    else
                    {
                        losesForDay++;
                        loses++;
                    }
                    sport = Console.ReadLine();
                }
                if(winsForDay > losesForDay)
                {
                    balanceForDay += balanceForDay * 0.10;
                }
                winsForDay = 0;
                losesForDay = 0;
                balance += balanceForDay;
                balanceForDay = 0;
            }
            if(wins > loses)
            {
                balance += balance * 0.20;
                Console.WriteLine($"You won the tournament! Total raised money: {balance:F2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {balance:F2}");
            }

        }
    }
}
