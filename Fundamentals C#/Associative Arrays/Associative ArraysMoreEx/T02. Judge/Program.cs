using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace T02._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" -> ");

            var contestResults = new Dictionary<string, Dictionary<string, int>>();
            var individualStandings = new SortedDictionary<string, int>();

            while (input[0] != "no more time")
            {
                string username = input[0];
                string contest = input[1];
                int points = int.Parse(input[2]);

                bool changePoints = false;

                if (contestResults.ContainsKey(contest) && (contestResults[contest].ContainsKey(username)))
                {
                    if (contestResults[contest][username] < points)
                    {
                        contestResults[contest][username] = points;
                        changePoints = true;
                    }
                }

                else if(contestResults.ContainsKey(contest))
                {
                    contestResults[contest].Add(username, points);
                }

                else
                {
                    contestResults.Add(contest, new Dictionary<string, int>());
                    contestResults[contest].Add(username, points);
                }

                if (individualStandings.ContainsKey(username) && !changePoints)
                    individualStandings[username] += points;

                else
                    individualStandings[username] = points;

                input = Console.ReadLine().Split(" -> ");
            }

            int line = 0;

            foreach(var contest in contestResults)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                Console.WriteLine(String.Join(Environment.NewLine, contest.Value
                    .OrderBy(n => n.Key)
                    .OrderByDescending(p => p.Value)
                    .Select(x => $"{++line}. {x.Key} <::> {x.Value}")));

                line = 0;
            }

            var sortedStanding = individualStandings.OrderByDescending(p => p.Value);

            Console.WriteLine("Individual standings:");
            
            foreach(var username in sortedStanding)
                Console.WriteLine($"{++line}. {username.Key} -> {username.Value}");
        }
    }
}
