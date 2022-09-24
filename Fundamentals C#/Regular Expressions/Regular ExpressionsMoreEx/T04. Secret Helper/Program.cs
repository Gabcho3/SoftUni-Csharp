using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T04._Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"@(?<name>[A-za-z]+)[\W]*[^@\-!:>]*!(?<type>[GN])!";

            int subtract = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            List<string> goodChildren = new List<string>();

            while(input != "end")
            {
                string result = string.Empty;

                foreach(char ch in input)
                {
                    int charCode = ch;

                    result += (char)(charCode - subtract);
                }

                var name = Regex.Match(result, patern).Groups["name"].Value;
                string type = Regex.Match(result, patern).Groups["type"].Value;

                if (type == "G")
                    goodChildren.Add(name);

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, goodChildren));
        }
    }
}
