using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @">>(?<name>[A-z]+)<<(?<price>\d+[.]?[0-9]+)!(?<quantity>\d+)\b";

            string input = Console.ReadLine();

            List<string> furnitures = new List<string>();

            double sum = 0;

            while(input != "Purchase")
            {
                Regex regex = new Regex(patern);
                Match valid = regex.Match(input);

                if (valid.Success)
                {
                    var name = valid.Groups["name"].Value;
                    var price = double.Parse(valid.Groups["price"].Value) * double.Parse(valid.Groups["quantity"].Value);

                    furnitures.Add(name);

                    sum += price;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            foreach (var furniture in furnitures)
                Console.WriteLine(furniture);

            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
