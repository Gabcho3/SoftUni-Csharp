using System;
using System.Text;

namespace T02._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            string result = string.Empty;

            foreach(string word in input)
            {
                for (int i = 0; i < word.Length; i++)
                    result += word;
            }

            Console.WriteLine(result);
        }
    }
}
