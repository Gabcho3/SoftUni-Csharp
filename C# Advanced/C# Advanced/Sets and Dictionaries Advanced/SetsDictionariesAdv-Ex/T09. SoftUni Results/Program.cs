using System;
using System.Collections.Generic;
using System.Linq;

namespace T09._SoftUni_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('-');
            var users = new SortedDictionary<string, int>(); //name, maxPoints
            var languages = new Dictionary<string, int>(); //language, count

            while (input[0] != "exam finished")
            {
                if (input[1] == "banned")
                {
                    users.Remove(input[0]);
                    input = Console.ReadLine().Split('-');
                    continue;
                }

                string user = input[0];
                string language = input[1];
                int points = int.Parse(input[2]);

                //In all cases:
                if (!languages.ContainsKey(language))
                    languages.Add(language, 1);

                else
                    languages[language] += 1;
                //Every submission counts

                if (!users.ContainsKey(user))
                    users.Add(user, points);

                else
                {
                    if (users[user] < points)
                        users[user] = points;
                }

                input = Console.ReadLine().Split('-');
            }

            Console.WriteLine("Results:");
            foreach (var (user, maxPoints) in users.OrderByDescending(x => x.Value))
                Console.WriteLine($"{user} | {maxPoints}");

            Console.WriteLine("Submissions:");
            foreach (var (language, count) in languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                Console.WriteLine($"{language} - {count}");
        } 
    }
}
