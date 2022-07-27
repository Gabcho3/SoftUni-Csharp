using System;
using System.Linq;

namespace T04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for(int rotation = 1; rotation <= rotations; rotation++)
            {
                int firstNum = nums[0];
                for(int i = 0; i < nums.Length - 1; i++) //rotation of numbers
                {
                    nums[i] = nums[i + 1];
                }
                nums[nums.Length - 1] = firstNum;
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
