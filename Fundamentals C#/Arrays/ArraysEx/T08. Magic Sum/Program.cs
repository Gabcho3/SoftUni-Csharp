using System;
using System.Linq;

namespace T08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int needSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < nums.Length; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == needSum)
                    {
                        Console.Write(nums[i] + " " + nums[j]);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
