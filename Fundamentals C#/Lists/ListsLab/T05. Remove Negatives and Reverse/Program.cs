using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            //OTHER SOLUTUION

            //nums.RemoveAll(num => num < 0);

            //nums.Reverse();

            //Console.WriteLine(string.Join(" ", nums));

            for (int i = 0; i < nums.Count; i++)
            {
                if(nums[i] < 0)
                {
                    nums.RemoveAt(i);
                    i--;
                }
            }

            if (nums.Count == 0)
                Console.WriteLine("empty");
            else
            {
                nums.Reverse();

                Console.WriteLine(string.Join(" ", nums));
            }
            
        }
    }
}
