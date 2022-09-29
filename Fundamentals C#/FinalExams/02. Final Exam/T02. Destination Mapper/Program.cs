using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace T02._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"([=]|[/])(?<place>[A-Z][A-Za-z]+)\1";
            var matches = Regex.Matches(Console.ReadLine(), patern);

            List<string> destinations = new List<string>();
            int points = 0;

            foreach(Match match in matches)
                if (match.Groups["place"].Value.Length >= 3)
                { 
                    destinations.Add(match.Groups["place"].Value);

                    points += match.Groups["place"].Value.Length;
                }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}
