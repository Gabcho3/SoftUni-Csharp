using System;
using System.Linq;

namespace T04._Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Very difficult to undrastand
            //Searching... for better solution
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[] upperRow = new int[input.Length / 2];
            int[] lowerRow = new int[input.Length / 2];

            int[] output = new int[input.Length / 2];

            
            for(int k = 0; k < upperRow.Length; k++)
            {
                if (k >= upperRow.Length / 2)
                {
                    for(int j = upperRow.Length / 2; j >= 1; j--)
                    { 
                        upperRow[k] = input[input.Length - j];
                        k++;
                    }
                }
                else
                    upperRow[k] = input[k];
            }

            for (int k = lowerRow.Length / 2; k <= input.Length - upperRow.Length / 2; k++)
            {
                for(int j = 0; j < lowerRow.Length; j++)
                {
                    lowerRow[j] = input[k];
                    k++;
                }
            }


            int[] upperRow1 = new int[upperRow.Length / 2]; //first digits
            int[] upperRow2 = new int[upperRow.Length / 2]; //last digits
            for(int j = 0; j < upperRow.Length / 2; j++)
            {
                upperRow1[j] = upperRow[j];
                upperRow2[j] = upperRow[upperRow.Length - j - 1];
            }
            Array.Reverse(upperRow1);

            int i = 0;

            for(; i < output.Length / 2; i++)
            {
                output[i] = upperRow1[i] + lowerRow[i];
            }
            for (; i < output.Length; i++)
            {
                for(int j = 0; j < upperRow2.Length; j++)
                {
                    output[i] = upperRow2[j] + lowerRow[i];
                    i++;
                }
            }

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
