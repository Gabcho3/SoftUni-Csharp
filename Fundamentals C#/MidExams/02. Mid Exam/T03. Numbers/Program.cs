using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> topNumbers = new List<int>();

            double average = integers.Average();

            foreach (int num in integers)
                if (num > average)
                    topNumbers.Add(num);

            topNumbers = topNumbers.OrderByDescending(n => n).ToList();

            if (topNumbers.Count > 5)
                topNumbers.RemoveRange(5, topNumbers.Count - 5);

            if (topNumbers.Count == 0)
                Console.WriteLine("No");

            else
                Console.WriteLine(String.Join(" ", topNumbers));
        }
    }
}
