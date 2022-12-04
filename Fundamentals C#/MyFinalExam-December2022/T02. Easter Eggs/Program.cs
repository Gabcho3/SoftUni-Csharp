using System;
using System.Text.RegularExpressions;

namespace T02._Easter_Eggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"[@#]+(?<color>[a-z]{3,})[@#]+\W*\/+(?<amount>[0-9]+)\/+";
            string input = Console.ReadLine();
            var matches = Regex.Matches(input, patern);

            foreach(Match match in matches)
            {
                string color = match.Groups["color"].Value;
                int amount = int.Parse(match.Groups["amount"].Value);

                Console.WriteLine($"You found {amount} {color} eggs!");
            }
        }
    }
}
