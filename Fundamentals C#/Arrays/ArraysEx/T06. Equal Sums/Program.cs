using System;
using System.Linq;

namespace T06._Equal_Sums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int leftSum = 0;
            int rightSum = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                    rightSum += nums[j];

                for (int k = i - 1; k >= 0; k--)
                    leftSum += nums[k];

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                rightSum = 0;
                leftSum = 0;
            }
            Console.WriteLine("no");
        }
    }
}
