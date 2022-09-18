using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml;

namespace T02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();

            int sum = CharacterMultiplier(strings[0], strings[1]);

            Console.WriteLine(sum);
        }

        public static int CharacterMultiplier(string str1, string str2)
        {
            int sum = 0;

            string longest = string.Empty;
            string shortest = string.Empty;

            if (str1.Length > str2.Length || str1.Length == str2.Length)
            {
                longest = str1;
                shortest = str2;
            }

            else 
            {
                longest = str2;
                shortest = str1;
            }

            for(int i = 0; i < longest.Length; i++)
            {
                if (i > shortest.Length - 1)
                    sum += longest[i];

                else
                    sum += longest[i] * shortest[i];
            }

            return sum;
        }
    }
}
