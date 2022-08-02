using System;

namespace T07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintMatrix(num);
        }

        static void PrintMatrix(int num)
        {
            int[] output = new int[num];

            for(int i = 0; i < output.Length; i++)
            {
                output[i] = num;
            }

            for(int j = 0; j < num; j++)
            {
                Console.WriteLine(string.Join(" ", output));
            }
        }
    }
}
