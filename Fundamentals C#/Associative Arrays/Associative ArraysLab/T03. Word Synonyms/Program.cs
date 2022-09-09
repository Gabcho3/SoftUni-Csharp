using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace T03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var synonyms = new Dictionary<string, List<string>>();

            for(int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();


                if (synonyms.ContainsKey(word))
                    synonyms[word].Add(synonym);

                else
                {
                    synonyms[word] = new List<string>();
                    synonyms[word].Add(synonym);
                }
            }

            foreach(var synonym in synonyms)
                Console.WriteLine($"{synonym.Key} - {string.Join(", ", synonym.Value)}");
        }
    }
}
