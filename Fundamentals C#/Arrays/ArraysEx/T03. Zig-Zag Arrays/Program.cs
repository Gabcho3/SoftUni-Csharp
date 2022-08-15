using System;
using System.Linq;

namespace T03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[int.Parse(Console.ReadLine())];
            int[] evenArray = new int[nums.Length];
            int[] oddArray = new int[nums.Length];

            for(int i = 0; i < nums.Length; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    evenArray[i] = numbers[0];
                    oddArray[i] = numbers[1];
                }
                else
                {
                    oddArray[i] = numbers[0];
                    evenArray[i] = numbers[1];
                }
            }
            Console.WriteLine(string.Join(" ", evenArray));
            Console.WriteLine(string.Join(" ", oddArray));
        }
    }
}
