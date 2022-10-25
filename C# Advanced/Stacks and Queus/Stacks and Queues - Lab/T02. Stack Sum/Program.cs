using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();

            Stack<int> stack = new Stack<int>();

            foreach (int num in integers)
                stack.Push(num);

            while (command[0] != "end")
            {
                if (command[0] == "add")
                {
                    stack.Push(int.Parse(command[1]));
                    stack.Push(int.Parse(command[2]));
                }

                else
                {
                    if (int.Parse(command[1]) < stack.Count)
                        for (int i = 0; i < int.Parse(command[1]); i++)
                            stack.Pop();
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
