using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split("!").ToList();
            string[] command = Console.ReadLine().Split().ToArray();

            while(command[0] != "Go")
            {
                string action = command[0];
                string item = command[1];

                switch(action)
                {
                    case "Urgent":
                        Urgent(groceries, item);
                        break;

                    case "Unnecessary":
                        Unnecessary(groceries, item);
                        break;

                    case "Correct":
                        string newItem = command[2];
                        Correct(groceries, item, newItem);
                        break;

                    case "Rearrange":
                        Rearrange(groceries, item);
                        break;
                }

                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(", ", groceries));
        }

        static void Urgent(List<string> groceries, string item)
        {
            if (!groceries.Contains(item))
                groceries.Insert(0, item);
        }

        static void Unnecessary(List<string> groceries, string item)
        {
            if (groceries.Contains(item))
                groceries.Remove(item);
        }

        static void Correct(List<string> groceries, string oldItem, string newItem)
        {
            for(int i = 0; i < groceries.Count; i++)
            {
                if (groceries[i].Equals(oldItem))
                {
                    groceries.RemoveAt(i);
                    groceries.Insert(i, newItem);
                    return;
                }
            }
        }

        static void Rearrange(List<string> groceries, string item)
        {
            if (groceries.Contains(item))
            {
                groceries.Remove(item);
                groceries.Add(item);
            }
        }
    }
}
