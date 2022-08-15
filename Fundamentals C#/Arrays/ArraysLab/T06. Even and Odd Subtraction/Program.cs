using System;
using System.Linq;

namespace T06._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int evenSum = 0;
            int oddSum = 0;

            foreach (int num in nums)
            {
                if (num % 2 == 0)
                    evenSum += num;
                else
                    oddSum += num;
            }
            int diff = evenSum - oddSum;
            Console.WriteLine(diff);
        }
    }
}
