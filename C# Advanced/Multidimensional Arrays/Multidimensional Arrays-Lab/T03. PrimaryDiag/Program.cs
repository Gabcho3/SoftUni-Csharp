using System;
using System.Linq;

namespace T03._PrimaryDiag_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = 0;
            for(int row = 0; row < matrix.Length; row++)
                for(int col = 0; col < matrix[row].Length; col++)
                    if(row == col)
                        sum += matrix[row][col];

            Console.WriteLine(sum);
        }
    }
}
