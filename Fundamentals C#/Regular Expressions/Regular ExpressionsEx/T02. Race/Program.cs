using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace T02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"\w";

            List<string> names = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            var racers = new Dictionary<string, int>();

            while (input != "end of race")
            {
                MatchCollection match = Regex.Matches(input, patern);

                string name = string.Empty;
                int km = 0;

                for(int i = 0; i < match.Count; i++)
                {
                    char ch = char.Parse(match[i].Value);

                    if (char.IsLetter(ch))
                        name += ch;

                    else
                        km += int.Parse(ch.ToString());
                }

                if (names.Contains(name))
                {
                    if (racers.ContainsKey(name))
                        racers[name] += km;

                    else
                        racers[name] = km;

                }

                input = Console.ReadLine();
            }

            var sortedRanking = racers.OrderByDescending(km => km.Value);

            int place = 1;

            foreach(var racer in sortedRanking)
            {
                if (place == 1)
                    Console.WriteLine($"1st place: {racer.Key}");

                else if (place == 2)
                    Console.WriteLine($"2nd place: {racer.Key}");

                else if (place == 3)
                    Console.WriteLine($"3rd place: {racer.Key}");

                else
                    return;

                place++;
            }
        }
    }
}
