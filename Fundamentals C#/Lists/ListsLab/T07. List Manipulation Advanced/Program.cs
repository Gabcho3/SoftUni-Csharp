using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split().ToArray();

            bool haveChange = false;

            while (command[0] != "end")
            {
                string action = command[0];

                haveChange = false;

                if (action == "Contains")
                    Contains(input, command);

                if (action == "PrintEven")
                    PrintEven(input);

                if (action == "PrintOdd")
                    PrintOdd(input);

                if (action == "GetSum")
                    GetSum(input);

                if (action == "Filter")
                    Filter(input, command);

                if (action == "Add")
                {
                    Add(input, command);
                    haveChange = true;
                }

                if (action == "Remove")
                {
                    Remove(input, command);
                    haveChange = true;
                }

                if (action == "RemoveAt")
                {
                    RemoveAt(input, command);
                    haveChange = true;
                }

                if (action == "Insert")
                {
                    Insert(input, command);
                    haveChange = true;
                }

                command = Console.ReadLine().Split().ToArray();
            }

            if (haveChange)
                Console.WriteLine(string.Join(" ", input));
        }

        static void Contains(List<int> input, string[] command)
        {
            bool isNumberExist = input.Contains(int.Parse(command[1]));

            if (isNumberExist)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No such number");
        }

        static void PrintEven(List<int> input)
        {
            foreach(int num in input)
            {
                if (num % 2 == 0)
                    Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static void PrintOdd(List<int> input)
        {
            foreach (int num in input)
            {
                if (num % 2 != 0)
                    Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static void GetSum(List<int> input)
        {
            int sum = 0;

            foreach (int num in input)
            {
                sum += num;
            }

            Console.WriteLine(sum);
        }

        static void Filter(List<int> input, string[] command)
        {
            List<int> currList = new List<int>();
            for(int i = 0; i < input.Count; i++)
            {
                currList.Add(input[i]);
            }

            switch (command[1])
            {
                case "<":
                    currList.RemoveAll(num => num >= int.Parse(command[2]));
                    break;
                case ">":
                    currList.RemoveAll(num => num <= int.Parse(command[2]));
                    break;
                case ">=":
                    currList.RemoveAll(num => num < int.Parse(command[2]));
                    break;
                case "<=":
                    currList.RemoveAll(num => num > int.Parse(command[2]));
                    break;
            }
            Console.WriteLine(string.Join(" ", currList));
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
