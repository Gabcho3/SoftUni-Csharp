using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace T02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"([:]{2}|[*]{2})(?<emoji>[A-Z][a-z]+)\1";

            string input = Console.ReadLine();

            var validEmojis = Regex.Matches(input, patern);

            int sum = 1;
            List<string> coolEmojis = new List<string>();

            int count = 0;

            for (int i = 0; i < input.Length; i++)
                if (char.IsDigit(input[i]))
                    sum *= int.Parse(input[i].ToString());

            for(int i = 0; i < validEmojis.Count; i++)
            {
                int ascciCode = 0;
                string emoji = Regex.Match(validEmojis[i].ToString(), patern).Groups["emoji"].Value;

                if (emoji.Length >= 3)
                {
                    for (int j = 0; j < emoji.Length; j++)
                        ascciCode += emoji[j];

                    if (ascciCode > sum)
                        coolEmojis.Add(validEmojis[i].ToString());

                    count++;
                }

            }

            Console.WriteLine($"Cool threshold: {sum}");
            Console.WriteLine($"{count} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join(Environment.NewLine, coolEmojis));
        }
    }
}
