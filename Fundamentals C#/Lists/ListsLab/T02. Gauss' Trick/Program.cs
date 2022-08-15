using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split().Select(double.Parse).ToList();

            for(int i = 0; i < nums.Count / 2; i++) //avoiding center num of List if nums.Count is odd
            {
                nums[i] += nums[nums.Count - 1]; //adding

                nums.RemoveAt(nums.Count - 1); //we added it to nums[i]
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
