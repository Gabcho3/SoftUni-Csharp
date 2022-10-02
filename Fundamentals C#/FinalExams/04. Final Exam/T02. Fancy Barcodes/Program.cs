using System;
using System.Text.RegularExpressions;

namespace T02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"@[#]+(?<item>[A-Z][A-Za-z\d]+[A-Z])@[#]+";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();

                var isSucces = Regex.Match(barcode, patern).Success;

                if (isSucces)
                {
                    var item = Regex.Match(barcode, patern).Groups["item"].Value;

                    if (item.Length < 6)
                    {
                        Console.WriteLine("Invalid barcode");
                        continue;
                    }

                    string group = string.Empty;

                    foreach (var ch in item)
                        if (char.IsDigit(ch))
                            group += ch;

                    if (group == "")
                        group = "00";

                    Console.WriteLine($"Product group: {group}");
                }

                else
                    Console.WriteLine("Invalid barcode");
            }
        }
    }
}
