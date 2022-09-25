using System;
using System.Text.RegularExpressions;

namespace T01._Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sidePatern = @"[\w@#$\^]{20}";
            string symbolPatern = @"[@]{6,10}|[#]{6,10}|[$]{6,10}|[\^]{6,10}";

            string splitPatern = @"[\s,]+";
            string input = Console.ReadLine();
            string[] tickets = Regex.Split(input, splitPatern);

            for (int i = 0; i < tickets.Length; i++)
            {
                var sideMatch = Regex.Matches(tickets[i], sidePatern);

                if (tickets[i].Length == 20)
                {
                    var symbolMatch = Regex.Matches(tickets[i].ToString(), symbolPatern);
                    if (symbolMatch.Count == 0)
                    {
                        Console.WriteLine($"ticket \"{tickets[i]}\" - no match");
                        continue;
                    }
                }


                if (sideMatch.Count == 0)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                var leftSymbolMatch = Regex.Matches(sideMatch[0].ToString(), symbolPatern);

                if (leftSymbolMatch[1].ToString().Length == leftSymbolMatch[0].ToString().Length)
                {
                    if (leftSymbolMatch[1].ToString().Length >= 6 && leftSymbolMatch[1].ToString().Length <= 9)
                    {
                        Console.WriteLine($"ticket \"{tickets[i]}\" - {leftSymbolMatch[1].ToString().Length}{leftSymbolMatch[1].ToString()[0]}");
                    }

                    if (leftSymbolMatch[1].ToString().Length == 10)
                        Console.WriteLine($"ticket \"{tickets[i]}\" - {leftSymbolMatch[1].ToString().Length}{leftSymbolMatch[1].ToString()[0]} Jackpot!");
                }
            }
        }
    }
}
