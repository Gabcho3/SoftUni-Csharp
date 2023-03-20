using System;
using System.Linq;
using System.Security.Claims;

namespace T04._SymbolMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rows, rows];
            string position = string.Empty;

            for (int row = 0; row < rows; row++)
            {
                string cols = Console.ReadLine();
                for (int col = 0; col < cols.Length; col++)
                    matrix[row, col] = cols[col];
            }

            char searchFor = char.Parse(Console.ReadLine());

            for(int row = 0; row < rows; row++)
                for(int col = 0; col < matrix.GetLength(1); col++)
                    if (matrix[row, col] == searchFor)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }

            Console.WriteLine($"{searchFor} does not occur in the matrix");
        }
    }
}
