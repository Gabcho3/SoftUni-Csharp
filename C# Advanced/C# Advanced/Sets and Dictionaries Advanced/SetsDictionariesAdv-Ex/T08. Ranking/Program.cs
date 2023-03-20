using System;
using System.Collections.Generic;
using System.Linq;

namespace T08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(':');
            var contests = new Dictionary<string, string>(); //contest, password
            var users = new Dictionary<string, Dictionary<string, int>>(); //username, [contest, points]

            while (input[0] != "end of contests")
            {
                string contest = input[0];
                string pass = input[1];
                contests.Add(contest, pass);

                input = Console.ReadLine().Split(':');
            }

            input = Console.ReadLine().Split("=>");

            while (input[0] != "end of submissions")
            {
                string contest = input[0];
                string pass = input[1];
                string username = input[2];
                int points = int.Parse(input[3]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == pass)
                    {
                        if (!users.ContainsKey(username))
                        {
                            users.Add(username, new Dictionary<string, int>());
                            users[username].Add(contest, points);
                        }

                        else if (!users[username].ContainsKey(contest))
                        {
                            users[username].Add(contest, points);
                        }

                        else if (users[username].ContainsKey(contest))
                        {
                            if (users[username][contest] < points)
                                users[username][contest] = points;
                        }
                    }
                }

                input = Console.ReadLine().Split("=>");
            }

            string bestCandidate = string.Empty;
            int mostPoints = 0;

            foreach (var user in users)
            {
                if(user.Value.Values.Sum() > mostPoints)
                {
                    mostPoints = user.Value.Values.Sum();
                    bestCandidate = user.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestCandidate} with total {mostPoints} points.");

            Console.WriteLine("Ranking:");
            foreach (var (user, contestS) in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(user);
                foreach (var (contest, points) in contestS.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
