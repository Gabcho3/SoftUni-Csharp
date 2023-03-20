using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            foreach (int integer in integers)
                queue.Enqueue(integer);

            List<int> output = new List<int>();

            while (queue.Count > 0)
            {
                int currInteger = queue.Peek();

                if (queue.Dequeue() % 2 == 0)
                    output.Add(currInteger);
            }

            Console.WriteLine(string.Join(", ", output));
        }
    }
}
