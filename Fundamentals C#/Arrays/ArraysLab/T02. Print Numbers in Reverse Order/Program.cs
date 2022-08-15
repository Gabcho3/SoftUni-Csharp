using System;

namespace T02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] numbers = new int[length];

            for(int index1 = 0; index1 < numbers.Length; index1++)
            {
                numbers[index1] = int.Parse(Console.ReadLine());
            }
            for(int index2 = length - 1; index2 >= 0; index2--) //length - 1 -> first index is always ZERO
            {
                Console.Write(numbers[index2] + " ");
            }
        }
    }
}
