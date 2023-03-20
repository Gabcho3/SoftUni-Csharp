using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace T02._SquaresMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                char[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < size[1]; col++)
                    matrix[row, col] = arr[col];
            }

            int count = 0;
            int[,] currMatrix = new int[2, 2];
            for (int row = 0; row < size[0] - 1; row++)
            {
                for (int col = 0; col < size[1] - 1; col++)
                {
                    char char1 = matrix[row, col];
                    char char2 = matrix[row, col + 1];
                    char char3 = matrix[row + 1, col];
                    char char4 = matrix[row + 1, col + 1];

                    if (char1 == char2 && char2 == char3 && char3 == char4)
                        count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
