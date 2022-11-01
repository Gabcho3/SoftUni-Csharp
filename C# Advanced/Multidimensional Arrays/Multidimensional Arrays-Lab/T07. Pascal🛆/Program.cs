using System;

namespace T07._Pascal_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] triangle = new long[rows][];

            for (int row = 0; row < rows; row++)
            {
                triangle[row] = new long[row + 1];
                for (int col = 0; col <= row; col++)
                {
                    if (col == 0)
                        triangle[row][col] = 1;

                    else if (col == row)
                        triangle[row][col] = 1;

                    else
                    {
                        triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                    }
                }
            }

            foreach (var col in triangle)
                Console.WriteLine(string.Join(" ", col));
        }
    }
}
