using System;
using System.Linq;

namespace T07._Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int sum = 0;
            for(int index = 0; index < input1.Length; index++) //input2.Length is SAME
            {
                int num = input2[index]; //no matter which input's index
                sum += num;
                if (input1[index] != input2[index]) 
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
                    return; //program ENDS
                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {sum}"); //if all is okay
        }
    }
}
