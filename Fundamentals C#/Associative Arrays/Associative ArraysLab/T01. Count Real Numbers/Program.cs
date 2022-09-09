using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var counts = new SortedDictionary<double, int>();

            foreach(var num in nums)
            {
                if (counts.ContainsKey(num))
                    counts[num]++;

                else
                    counts[num] = 1;
            }

            foreach(var number in counts)
                Console.WriteLine($"{number.Key} -> {number.Value}");
        }
    }
}
