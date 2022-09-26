using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace T02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"(?<s>[#]|[|])(?<item>[A-Za-z\s]+)\k<s>(?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\k<s>(?<kcal>[\d]+)\k<s>";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, patern);

            var output = new StringBuilder();

            int totalKcal = 0;

            foreach(Match match in matches)
            {
                string data = match.ToString();

                string name = Regex.Match(data, patern).Groups["item"].Value;
                string date = Regex.Match(data, patern).Groups["date"].Value;
                int calories = int.Parse(Regex.Match(data, patern).Groups["kcal"].Value);

                totalKcal += calories;

                output.Append($"Item: {name}, Best before: {date}, Nutrition: {calories}\n");
            }

            int days = totalKcal / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");
            Console.WriteLine(output);
        }
    }
}
