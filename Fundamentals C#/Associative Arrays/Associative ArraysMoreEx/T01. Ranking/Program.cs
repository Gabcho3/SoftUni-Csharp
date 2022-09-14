using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace T01._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(':');

            var contestsPasswords = new SortedDictionary<string, string>();
            var pointsByUser = new SortedDictionary<string, Dictionary<string, int>>(); //Key -> name, Value -> Key: contest, Value: points

            while (input[0] != "end of contests")
            {
                contestsPasswords.Add(input[0], input[1]);

                input = Console.ReadLine().Split(':');
            }

            input = Console.ReadLine().Split("=>");

            //Adding user data for contests
            while (input[0] != "end of submissions")
            {
                string contest = input[0];
                string pass = input[1];
                string name = input[2];
                int points = int.Parse(input[3]);

                if (pointsByUser.ContainsKey(name) && pointsByUser[name].ContainsKey(contest))
                {
                    if (pointsByUser[name][contest] < points)
                        pointsByUser[name][contest] = points;
                }

                else if(pointsByUser.ContainsKey(name))
                {
                    if (contestsPasswords[contest] == pass)
                        pointsByUser[name].Add(contest, points);
                }

                else
                {
                    if (contestsPasswords.ContainsKey(contest))
                    {
                        if (contestsPasswords[contest] == pass)
                        {
                            pointsByUser.Add(name, new Dictionary<string, int>());
                            pointsByUser[name].Add(contest, points);
                        }
                    }
                }

                input = Console.ReadLine().Split("=>");
            }

            //Finding best candidate
            string best = string.Empty;
            int mostPoints = 0;

            foreach (var user in pointsByUser)
            {
                if (user.Value.Values.Sum() > mostPoints)
                {
                    best = user.Key;
                    mostPoints = user.Value.Values.Sum();
                }
            }

            Console.WriteLine($"Best candidate is {best} with total {mostPoints} points.");

            Console.WriteLine("Ranking: ");

            //Printing users for each contes
            foreach(var user in pointsByUser)
            {
                Console.WriteLine(user.Key);

                Console.WriteLine(string.Join(Environment.NewLine, user.Value.OrderByDescending(p => p.Value).Select(u => $"#  {u.Key} -> {u.Value}")));
            }
        }
    }
}
