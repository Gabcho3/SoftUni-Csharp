using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            double avarage = nums.Sum() / (double)nums.Count; //(double) --> we need 1 double min int calculations

            nums.RemoveAll(num => num <= avarage);

            if (nums.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            nums.Sort();
            nums.Reverse();

            if(nums.Count > 5)
            {
                int lastNum = nums[4];
                nums.RemoveAll(num => num < lastNum);
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
