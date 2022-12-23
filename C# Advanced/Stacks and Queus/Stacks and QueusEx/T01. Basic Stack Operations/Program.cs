using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int[] commands = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int[] integers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            int toPush = commands[0]; int toPop = commands[1]; int toFind = commands[2];

            foreach (int num in integers)
            {
                stack.Push(num);
                toPush--;
                if (toPush == 0)
                    break;
            }

            while (toPop > 0)
            {
                stack.Pop();
                toPop--;
            }

            Console.WriteLine(stack.Contains(toFind) ? "true" : stack.Count == 0 ? "0" : stack.Min().ToString());
        }
    }
}
