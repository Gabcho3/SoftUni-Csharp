using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._SetsofElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = lengths[0];
            int m = lengths[1];

            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }

            foreach(var num1 in set1)
            {
                foreach(var num2 in set2)
                {
                    if (num1 == num2)
                        Console.Write(num1 + " ");
                }
            }
        }
    }
}
