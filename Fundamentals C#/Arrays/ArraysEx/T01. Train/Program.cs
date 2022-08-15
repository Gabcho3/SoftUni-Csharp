using System;
using System.Linq;
namespace T01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[int.Parse(Console.ReadLine())];

            int sum = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
                sum += nums[i];
            }
            Console.WriteLine(string.Join(" ", nums));
            Console.WriteLine(sum);
        }
    }
}
