using System;
using System.Linq;
using System.Numerics;

namespace T05._SquareMaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < sizes[0]; row++)
            {
                int[] arr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < sizes[1]; col++)
                    matrix[row, col] = arr[col];
            }

            int[,] bestSquare = new int[2, 2];
            int sum = 0;
            int bestSum = 0;
            for (int row = 0; row < sizes[0] - 1; row++)
            {
                for (int col = 0; col < sizes[1] - 1; col++)
                {
                    sum += matrix[row, col];
                    sum += matrix[row, col + 1];
                    sum += matrix[row + 1, col];
                    sum += matrix[row + 1, col + 1];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestSquare[0, 0] = matrix[row, col];
                        bestSquare[0, 1] = matrix[row, col + 1];
                        bestSquare[1, 0] = matrix[row + 1, col];
                        bestSquare[1, 1] = matrix[row + 1, col + 1];
                    }

                    sum = 0;
                }
            }

            int count = 0;
            foreach (var col in bestSquare)
            {
                count++;
                Console.Write(col + " ");

                if (count % 2 ==  0)
                    Console.WriteLine();
            }

            Console.WriteLine(bestSum);
        }
    }
}
