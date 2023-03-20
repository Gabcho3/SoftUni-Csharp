using System;
using System.Collections.Generic;

namespace T03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<char> expressions = new List<char>();
            Stack<string> stack = new Stack<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if(i % 2 != 0)
                    expressions.Add(char.Parse(input[i]));

                else
                    stack.Push(input[i]);
            }

            expressions.Reverse();
            int result = int.Parse(stack.Pop());

            foreach (char c in expressions)
            {
                if (c == '+')
                    result += int.Parse(stack.Pop());

                else
                    result -= int.Parse(stack.Pop());
            }

            Console.WriteLine(result);
        }
    }
}
