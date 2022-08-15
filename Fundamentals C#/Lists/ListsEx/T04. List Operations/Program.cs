using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split(" ").ToArray();

            string action = command[0].ToString();

            while (action != "End")
            {
                if (action == "Add")
                    list.Add(int.Parse(command[1]));

                if (action == "Insert")
                {
                    if (int.Parse(command[2]) > list.Count - 1 || int.Parse(command[2]) < 0)
                        Console.WriteLine("Invalid index");

                    else
                        list.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }

                if (action == "Remove")
                {
                    if (int.Parse(command[1]) > list.Count - 1 || int.Parse(command[1]) < 0)
                        Console.WriteLine("Invalid index");

                    else
                        list.RemoveAt(int.Parse(command[1]));
                }

                if (action == "Shift")
                    Shift(list, command);

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                action = command[0].ToString();
            }

            Console.WriteLine(string.Join(" ", list));
        }

        static void Shift(List<int> list, string[] command)
        {
            for(int i = 0; i < int.Parse(command[2]); i++)
            {

                if (command[1] == "left")
                {
                    list.Add(list[0]);
                    list.RemoveAt(0);
                }

                else
                {
                    list.Insert(0, list[list.Count - 1]);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
    }
}