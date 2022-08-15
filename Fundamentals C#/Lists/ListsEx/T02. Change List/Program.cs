using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split().ToArray();
            string action = command[0];


            while(action != "end")
            {
                switch(action)
                {
                    case "Delete":
                        list.RemoveAll(n => n == int.Parse(command[1]));
                        break;

                    case "Insert":
                        list.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                }

                command = Console.ReadLine().Split().ToArray();
                action = command[0];
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
