using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list1 = Console.ReadLine().Split().ToList();
            List<string> list2 = Console.ReadLine().Split().ToList();

            List<string> result = new List<string>();

            int biggererListCount = Math.Max(list1.Count, list2.Count);

            for (int i = 0; i < biggererListCount; i++)
            {
                if (list1.Count > i)
                    result.Add(list1[i]);

                if(list2.Count > i)
                    result.Add(list2[i]);
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
