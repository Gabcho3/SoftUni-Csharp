using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            var charCount = new Dictionary<char, int>();

            for(int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                for(int j = 0; j < word.Length; j++)
                {
                    if (charCount.ContainsKey(word[j]))
                        charCount[word[j]]++;

                    else
                        charCount[word[j]] = 1;
                }
            }

            foreach(var ch in charCount)
                Console.WriteLine($"{ch.Key} -> {ch.Value}");
        }
    }
}
