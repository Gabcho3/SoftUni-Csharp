using System;
using System.Collections.Generic;

namespace T01._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            for(int i = 0; i < input.Length; i++)
                stack.Push(input[i]);

            for (int i = 0; i < stack.Count; i++)
            {
                Console.Write(stack.Pop());
                i--;
            }

            //OR:
            //Console.WriteLine(string.Join("", stack));
        }
    }
}
