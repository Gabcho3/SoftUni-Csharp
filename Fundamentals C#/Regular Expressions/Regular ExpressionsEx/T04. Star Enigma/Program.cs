using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern1 = @"[STARstar]";

            string patern2 = @"[^@\-!\:>]*@(?<name>[A-z]+)[^@\-!\:>]*:(?<population>\d+)[^@\-!\:>]*"+
                             @"!(?<type>[A|D])![^@\-!\:>]*->(?<count>\d+)";

            int n = int.Parse(Console.ReadLine());

            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            for(int i = 0; i < n; i++)
            {
                StringBuilder input = new StringBuilder();
                input.Append(Console.ReadLine());

                var matchCount = Regex.Matches(input.ToString(), patern1).Count;

                for(int j = 0; j < input.Length; j++)
                {
                    int charCode =  input[j] - matchCount;

                    input = input.Replace(input[j], (char)charCode, j, 1);
                }

                Match validMessage = Regex.Match(input.ToString(), patern2);

                if (validMessage.Success)
                {
                    var name = validMessage.Groups["name"].Value;
                    var type = validMessage.Groups["type"].Value;

                    if (type == "A")
                        attacked.Add(name);

                    else
                        destroyed.Add(name);
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");

            if (attacked.Count > 0) //if(count == 0) there is new line
                Console.WriteLine(string.Join(Environment.NewLine, attacked.OrderBy(n => n).Select(x => $"-> {x}")));

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");

            if (destroyed.Count > 0)
                Console.WriteLine(string.Join(Environment.NewLine, destroyed.OrderBy(n => n).Select(x => $"-> {x}")));
        }
    }
}
