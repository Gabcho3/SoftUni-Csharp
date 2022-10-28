using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                int value = input[i];

                if (i == 0)
                {
                    for (int f = 0; f < nums.Length; f++)
                    {
                        stack.Push(nums[f]);

                        if (f == value - 1)
                            break;
                    }
                }

                else if (i == 1)
                {
                    while (value >= 1)
                    {
                        stack.Pop();
                        value--;
                    }
                }

                else
                {
                    if (stack.Contains(value))
                        Console.WriteLine("true");

                    else if (stack.Count == 0)
                        Console.WriteLine(0);


                    else if (!stack.Contains(value))
                        Console.WriteLine(stack.Min());
                }
            }
            
        }
    }
}
