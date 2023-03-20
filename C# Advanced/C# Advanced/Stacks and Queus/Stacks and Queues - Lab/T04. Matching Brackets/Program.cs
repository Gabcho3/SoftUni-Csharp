using System;
using System.Collections;
using System.Collections.Generic;

namespace T04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            int openIndex = 0;
            int closeIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                    stack.Push(i);

                if (input[i] == ')')
                {
                    openIndex = stack.Pop();
                    Console.WriteLine(input.Substring(openIndex, i - openIndex + 1));
                }
            }
        }
    }
}
