using System;
using System.Collections.Generic;

namespace T06._Record_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int names = int.Parse(Console.ReadLine());
            var uniqueNames = new HashSet<string>();
            for(int i = 0; i < names; i++)
            {
                string name = Console.ReadLine();
                uniqueNames.Add(name);
            }

            foreach (var name in uniqueNames)
                Console.WriteLine(name);
        }
    }
}
