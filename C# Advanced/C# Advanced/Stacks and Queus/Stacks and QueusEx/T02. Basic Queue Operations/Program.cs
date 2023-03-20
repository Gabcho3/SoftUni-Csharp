using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            int add = input[0];
            int remove = input[1];
            int lookFor = input[2];

            for (int i = 0; i < nums.Length; i++)
            {
                queue.Enqueue(nums[i]);

                if (queue.Count == add)
                    break;
            }

            while (remove >= 1)
            {
                queue.Dequeue();
                remove--;
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            string output = queue.Contains(lookFor) ? "true" : queue.Min().ToString();
            Console.WriteLine(output);
        }
    }
}
