using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var symbolsCount = new Dictionary<char, int>();

            foreach(var ch in input)
            {
                if(!symbolsCount.ContainsKey(ch))
                    symbolsCount[ch] = 0;

                symbolsCount[ch]++;
            }
            
            symbolsCount = symbolsCount.OrderBy(s => s.Key).ToDictionary(x => x.Key, x => x.Value); //we can also make Dictionary -> SortedDictionary
            foreach (var symbol in symbolsCount)
                Console.WriteLine(symbol.Key + ": " + symbol.Value + " time/s");
        }
    }
}
