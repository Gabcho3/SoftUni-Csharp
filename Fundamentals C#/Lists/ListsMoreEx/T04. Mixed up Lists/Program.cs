using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> mix = new List<int>();

            for (int i = 0; i < list1.Count; i++)
            {
                for (int j = list2.Count - 1; j >= 0; j--)
                {
                    if (i < list1.Count)
                    {
                        mix.Add(list1[i]);
                        i++;
                    }
                    mix.Add(list2[j]);
                }
            }

            int skip1 = mix[mix.Count - 1];
            int skip2 = mix[mix.Count - 2];

            List<int> result = new List<int>();

            for(int i = 0; i < mix.Count; i++)
            {
                if (mix[i] > skip1 && mix[i] < skip2 || mix[i] < skip1 && mix[i] > skip2)
                    result.Add(mix[i]);
            }

            result.Sort();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
