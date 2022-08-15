using System;
using System.Linq;
using System.Collections.Generic;

namespace T06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                    Add(input, command);

                if (command[0].ToString() == "Remove")
                    Remove(input, command);

                if (command[0].ToString() == "RemoveAt")
                    RemoveAt(input, command);

                if (command[0].ToString() == "Insert")
                    Insert(input, command);

                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(" ", input));
        }

        static void Add(List<int> input, string[] command)
        {
            input.Add(int.Parse(command[1]));
        }

        private static void Remove(List<int> input, string[] command)
        {
            input.Remove(int.Parse(command[1]));
        }

        private static void RemoveAt(List<int> input, string[] command)
        {
            input.RemoveAt(int.Parse(command[1]));
        }

        private static void Insert(List<int> input, string[] command)
        {
            input.Insert(int.Parse(command[2]), int.Parse(command[1]));
        }
    }
}
