using System;
using System.Collections.Generic;
using System.Linq;

namespace Т03._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ").ToList();
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "Craft!")
            {
                switch(command[0])
                {
                    case "Collect":
                        Collect(items, command);
                        break;

                    case "Drop":
                        Drop(items, command);
                        break;

                    case "Combine":
                        Combine(items, command);
                        break;

                    case "Renew":
                        Renew(items, command);
                        break;
                }

                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(", ", items));
        }

        static void Collect(List<string> items, string[] command)
        {
            string item = command[2];

            if (!items.Contains(item))
                items.Add(item);
        }

        static void Drop(List<string> items, string[] command)
        {
            string item = command[2];

            if (items.Contains(item))
                items.Remove(item);
        }

        static void Combine(List<string> items, string[] command)
        {
            string[] oldNewItem = command[3].Split(":");

            string oldItem = oldNewItem[0];
            string newItem = oldNewItem[1];

            for(int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(oldItem))
                {
                    items.Insert(i + 1, newItem);
                    return;
                }
            }
        }

        static void Renew(List<string> items, string[] command)
        {
            string item = command[2];

            if (items.Contains(item))
            {
                items.Remove(item);
                items.Add(item);
            }
        }
    }
}
