using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace T02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().Select(w => w.ToLower()).ToArray();

            var counts = new Dictionary<string, int>();


            //CASE-INSENSITIVE!

            foreach (var word in words)
            {
                if (counts.ContainsKey(word))
                    counts[word]++;

                else
                    counts.Add(word, 1); 
            }

            var output = counts.Where(v => v.Value % 2 == 1);

            foreach (var word in output)
                Console.Write(word.Key + " ");
        }
    }
}
