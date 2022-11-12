using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Largest_3Nums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            list = list.OrderByDescending(x => x).ToList();
            int count = 0;
            foreach (int i in list)
            {
                count++;
                if (count <= 3)
                    Console.Write(i + " ");
            }
        }
    }
}
