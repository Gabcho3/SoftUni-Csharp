using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(input);

            for (int i = 0; i < input.Length; i++)
            {
                if (food - input[i] >= 0)
                    food -= queue.Dequeue();

                else
                    break;
            }

            Console.WriteLine(input.Max());

            string output = queue.Count == 0 ? "Orders complete" : $"Orders left: {string.Join(" ", queue)}";
            Console.WriteLine(output);
        }
    }
}
