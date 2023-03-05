using _08.Collecti.Classes;
using System;

namespace _08.Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int itemsToRemove = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            Console.WriteLine(string.Join(" ", addCollection.Add(items)));

            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            Console.WriteLine(string.Join(" ", addRemoveCollection.Add(items)));

            MyList myList = new MyList();
            Console.WriteLine(string.Join(" ", myList.Add(items)));

            Console.WriteLine(string.Join(" ", addRemoveCollection.Remove(itemsToRemove)));
            Console.WriteLine(string.Join(" ", myList.Remove(itemsToRemove)));
        }
    }
}
