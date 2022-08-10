using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> arrays = Console.ReadLine().Split("|").ToList(); //removing all "|"
            List<string> input = new List<string>();

            for (int i = arrays.Count - 1; i >= 0; i--)
            {
                List<string> currList = arrays[i]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList(); //removing all " "

                for(int j = 0; j < currList.Count; j++)
                {
                    input.Add(currList[j]);
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
