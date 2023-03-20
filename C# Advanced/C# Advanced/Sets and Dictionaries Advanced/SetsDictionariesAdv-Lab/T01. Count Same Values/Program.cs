using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Count_Same_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var numsInfo = new Dictionary<double, int>(); //num, times

            foreach (var number in nums)
            {
                if(numsInfo.ContainsKey(number))
                {
                    numsInfo[number] += 1;
                }

                else
                {
                    numsInfo[number] = 1;
                }
            }

            foreach(var (num, times) in numsInfo)
            {
                Console.WriteLine($"{num} - {times} times");
            }
        }
    }
}
