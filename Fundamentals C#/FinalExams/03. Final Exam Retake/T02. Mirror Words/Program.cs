using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;

namespace T02._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputPatern = @"([@]|[#])[A-Za-z]+\1\1[A-Za-z]+\1";
            string pairsPatern = @"[A-Za-z]+";

            string input = Console.ReadLine();

            var validPairs = Regex.Matches(input, inputPatern);
            var pairs = new Dictionary<string, string>();

            if (validPairs.Count == 0)
                Console.WriteLine("No word pairs found!");

            int validPairsCount = 0;

            for (int i = 0; i < validPairs.Count; i++)
            {
                var words = Regex.Matches(validPairs[i].ToString(), pairsPatern);

                if (words[0].ToString().Length >= 3)
                {
                    string reversedSecondWord = string.Empty;

                    for (int j = words[1].ToString().Length - 1; j >= 0; j--)
                        reversedSecondWord += words[1].ToString()[j];

                    if (reversedSecondWord == words[0].ToString())
                        pairs[words[0].ToString()] = words[1].ToString();

                    validPairsCount++;
                }
            }

            if (validPairs.Count > 0)
                Console.WriteLine($"{validPairsCount} word pairs found!");

            if (pairs.Count == 0)
                Console.WriteLine("No mirror words!");

            else
            {
                Console.WriteLine("The mirror words are:");

                Console.WriteLine(string.Join(", ", pairs.Select(p => $"{p.Key} <=> {p.Value}")));
            }
        }
    }
}
