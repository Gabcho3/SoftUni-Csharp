using System;
using System.Linq;

namespace T01._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');

            Random randomIndex = new Random();

            for(int i = 0; i < words.Length; i++)
            {
                int newIndex = randomIndex.Next(0, words.Length);

                string currWord = words[i];

                words[i] = words[newIndex];
                words[newIndex] = currWord;
            }

            foreach(string word in words)
                Console.WriteLine(word);
        }
    }
}
