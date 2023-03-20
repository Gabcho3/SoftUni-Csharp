using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace T08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            string output = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];

                if(ch == '(' || ch == '{' || ch == '[')
                    stack.Push(ch);

                else
                {
                    if (stack.Count == 0)
                    {
                        output = "NO";
                        break;
                    }

                    char currChar = stack.Peek();

                    if((currChar == '(' && ch == ')') || 
                       (currChar == '{' && ch == '}') || 
                       (currChar == '[' && ch == ']') )
                    {
                        stack.Pop();
                        output = "YES";
                    }

                    else
                    {
                        output = "NO";
                        break;
                    }
                }
            }

            Console.WriteLine(output);
        }   
    }
}
