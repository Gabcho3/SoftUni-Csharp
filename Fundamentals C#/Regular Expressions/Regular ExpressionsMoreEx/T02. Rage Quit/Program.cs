using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T02._Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringPatern = @"[^0-9]+";
            string numPatern = @"\d+";

            string input = Console.ReadLine();

            var stringMatch = Regex.Matches(input, stringPatern);
            var numMatch = Regex.Matches(input, numPatern);

            List<char> chars = new List<char>();

            foreach (var str in stringMatch)
                for (int i = 0; i < str.ToString().Length; i++)
                    if (!chars.Contains(str.ToString().ToUpper()[i]))
                        chars.Add(str.ToString().ToUpper()[i]);

            Console.WriteLine($"Unique symbols used: {chars.Count}");

            for (int i = 0; i < numMatch.Count; i++)
                for (int j = 0; j < int.Parse(numMatch[i].ToString()); j++)
                    Console.Write(stringMatch[i].ToString().ToUpper());
        }
    }
}
