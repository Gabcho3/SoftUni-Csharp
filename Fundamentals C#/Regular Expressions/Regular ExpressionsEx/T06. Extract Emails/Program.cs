using System;
using System.Text.RegularExpressions;

namespace T06._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"(?<user>^[A-Za-z\d]+[.\-_]?[A-Za-z\d]*)@(?<host>[A-z]+[-]?[a-z]+[.]{1}[a-z]+[.]?[a-z]+)";

            string[] input = Console.ReadLine().Split();

            foreach(string s in input)
            {
                var match = Regex.Match(s, patern);

                if (match.Success)
                    Console.WriteLine(match);
            }
        }
    }
}
