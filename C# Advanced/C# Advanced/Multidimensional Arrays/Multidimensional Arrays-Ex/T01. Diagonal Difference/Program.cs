using System;
using System.Linq;

namespace T01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];

            for(int i = 0; i < n; i++)
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int toRightSum = 0;
            int col = 0;
            for (int row = 0; row < n; row++)
            {
                toRightSum += matrix[row][col];
                col++;
            }

            int toLeftSum = 0;
            col = n - 1;
            for (int row = 0; row < n; row++)
            {
                toLeftSum += matrix[row][col];
                col--;
            }

            Console.WriteLine(Math.Abs(toRightSum - toLeftSum));
        }
    }
}
