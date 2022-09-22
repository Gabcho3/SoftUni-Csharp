using System;
using System.Text.RegularExpressions;

namespace T01._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            string names = Console.ReadLine();

            MatchCollection matchedNames = Regex.Matches(names, patern);

            foreach (Match name in matchedNames)
                Console.Write($"{name.Value} ");

        }
    }
}
