using System;

namespace T04._Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] nums = new int[num];

            PrintSequence(nums);
        }

        static void PrintSequence(int[] nums)
        {
            int numCounter = 0;
            nums[0] = 1;

            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = 1; j <= numCounter; j++)
                {
                    nums[i] += nums[i - j];
                }

                numCounter++;

                if (numCounter == 4)
                    numCounter--; //must be always maximum  3
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
