using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var elements = new HashSet<string>();

            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                for(int j = 0; j < input.Length; j++)
                {
                    elements.Add(input[j]);
                }
            }

            elements = elements.OrderBy(e => e).ToHashSet();

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
