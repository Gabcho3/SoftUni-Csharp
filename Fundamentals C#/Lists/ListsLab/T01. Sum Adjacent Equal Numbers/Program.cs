using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Sum_Adjacent_Equal_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split().Select(double.Parse).ToList();

            for(int i = 0; i < nums.Count - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    nums[i] += nums[i + 1];

                    nums.RemoveAt(i + 1); //added it to nums[i]

                    i = -1; //to reset the loop 
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
