using System;
using System.Linq;

namespace T03._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); 
            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < size[1]; col++)
                    matrix[row, col] = arr[col];
            }

            int[,] bestSquare = new int[3,3];
            int bestSum = 0;
            for (int row = 0; row < size[0] - 2; row++)
            {
                for (int col = 0; col < size[1] - 2; col++)
                {
                    int[,] currSquare = new int[3, 3];
                    int sum = 0;

                    currSquare[0,0] = matrix[row, col];
                    currSquare[0,1] = matrix[row, col + 1];
                    currSquare[0,2] = matrix[row , col + 2];

                    currSquare[1,0] = matrix[row + 1, col];
                    currSquare[1,1] = matrix[row + 1, col + 1];
                    currSquare[1,2] = matrix[row + 1, col + 2];

                    currSquare[2,0] = matrix[row + 2, col];
                    currSquare[2,1] = matrix[row + 2, col + 1];
                    currSquare[2,2] = matrix[row + 2, col + 2];

                    foreach (var value in currSquare)
                        sum += value;

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestSquare = currSquare;
                    }
                }
            }

            Console.WriteLine($"Sum = {bestSum}");

            int count = 0;
            foreach (var num in bestSquare)
            {
                count++;
                Console.Write(num + " ");

                if(count % 3 == 0 && count != 0)
                    Console.WriteLine();
            }
        }
    }
}
