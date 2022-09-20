using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string output = string.Empty;

            int strength = 0;

            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());

                    output += input[i];
                }

                else if (strength == 0)
                    output += input[i];

                else
                    strength--;
            }

            Console.WriteLine(output);
        }
    }
}
