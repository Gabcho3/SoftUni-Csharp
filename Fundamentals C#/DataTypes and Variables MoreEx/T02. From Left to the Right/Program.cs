using System;
using System.Linq;

namespace T02._From_Left_to_the_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SOLUTION WITH ARRAY
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                long [] nums = Console.ReadLine().Split().Select(long.Parse).ToArray();
                long sum = 0;

                if (nums[0] >= nums[1])
                {
                    long digits = nums[0];

                    while (digits != 0)
                    {
                        long currDigit = digits % 10;

                        sum += currDigit;

                        digits /= 10;
                    }
                    Console.WriteLine(Math.Abs(sum));
                }

                else
                {
                    long digits = nums[1];

                    while (digits != 0)
                    {
                        long currDigit = digits % 10;

                        sum += currDigit;

                        digits /= 10;
                    }
                    Console.WriteLine(Math.Abs(sum));
                }
            }
        }

    }
}
