using System;
using System.Collections.Generic;

namespace T09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();

            string str = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "1":
                        str += command[1];
                        stack.Push(str);
                        break;

                    case "2":
                        int count = int.Parse(command[1]);
                        str = str.Remove(str.Length - count, count);
                        stack.Push(str);
                        break;

                    case "3":
                        int index = int.Parse(command[1]) - 1;
                        Console.WriteLine(str[index]);
                        break;

                    case "4":
                        string currString = str;

                        if (stack.Count == 0)
                            str = "";

                        else
                            while (str == currString)
                            {
                                if (str != stack.Peek())
                                    str = stack.Pop();

                                else
                                    stack.Pop();
                            }
                        break;
                }
            }
        }
    }
}
