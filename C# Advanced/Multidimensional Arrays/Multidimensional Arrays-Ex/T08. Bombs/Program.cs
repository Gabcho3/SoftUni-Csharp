using System;
using System.Linq;

namespace T08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rowsAndCols, rowsAndCols];

            for (int row = 0; row < rowsAndCols; row++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < rowsAndCols; col++)
                    matrix[row, col] = arr[col];
            }

            string[] bombs = Console.ReadLine().Split();

            for (int i = 0; i < bombs.Length; i++)
            {
                int[] data = bombs[i].Split(',').Select(int.Parse).ToArray();
                int row = data[0];
                int col = data[1];

                if (matrix[row, col] > 0)
                {
                    int bomb = matrix[row, col];
                    matrix[row, col] = 0;
                    BombExplotion(matrix, row, col, bomb);
                }
            }

            int aliveCells = 0;
            int sum = 0;
            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sum += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}\nSum: {sum}");

            int count = 0;
            foreach (var cell in matrix)
            {
                count++;
                Console.Write(cell + " ");

                if (count % rowsAndCols == 0)
                    Console.WriteLine();
            }
        }

        static void BombExplotion(int[,] matrix, int row, int col, int bomb)
        {
            for (int r = row - 1; r <= row + 1; r++)
            {
                if (r < 0 || r >= matrix.GetLength(0))
                    continue;

                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (c < 0 || c >= matrix.GetLength(1))
                        continue;

                    if (matrix[r, c] > 0)
                        matrix[r, c] -= bomb;
                }
            }
        }
    }
}