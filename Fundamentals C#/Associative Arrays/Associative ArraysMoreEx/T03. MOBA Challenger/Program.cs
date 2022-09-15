using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");

            var playersStats = new SortedDictionary<string, SortedDictionary<string, int>>();

            while (input[0] != "Season")
            {
                if(input.Length == 3) //player vs player
                {
                    string player1 = input[0];
                    string player2 = input[2];

                    bool isValidDuel = false;

                    if (playersStats.ContainsKey(player1) && playersStats.ContainsKey(player2))
                    {
                        foreach(var p1 in playersStats[player1])
                        {
                            foreach(var p2 in playersStats[player2])
                            {
                                if (p1.Key == p2.Key)
                                    isValidDuel = true;
                            }
                        }
                    }

                    if(isValidDuel)
                    {
                        if (playersStats[player1].Values.Sum() > playersStats[player2].Values.Sum())
                            playersStats.Remove(player2);

                        else
                            playersStats.Remove(player1);
                    }
                }

                else //player -> position -> skill"
                {
                    string player = input[0];
                    string position = input[2];
                    int skill = int.Parse(input[4]);

                    if (playersStats.ContainsKey(player) && playersStats[player].ContainsKey(position))
                    {
                        if (playersStats[player][position] < skill)
                            playersStats[player][position] = skill;
                    }

                    else if (playersStats.ContainsKey(player))
                    {
                        playersStats[player].Add(position, skill);
                    }

                    else
                    {
                        playersStats[player] = new SortedDictionary<string, int>();
                        playersStats[player].Add(position, skill);
                    }
                }

                input = Console.ReadLine().Split(" ");
            }

            var sortedStats = playersStats.OrderByDescending(s => s.Value.Values.Sum());

            foreach(var player in sortedStats)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                Console.WriteLine(string.Join(Environment.NewLine, player.Value.OrderByDescending(p => p.Value).Select(u => $"- {u.Key} <::> {u.Value}")));
            }
        }
    }
}
