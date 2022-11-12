using System;

namespace T07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            char[,] board = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string arr = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                    board[row, col] = arr[col];
            }

            int result = 0;
            while (true)
            {
                int maxKnightsRemove = 0;
                int[] rowAndColsToRemove = new int[2];

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            int knightsRemove = 0;
                            if (IsCellValid(row - 2, col - 1, rows, cols))
                            {
                                if (board[row - 2, col - 1] == 'K')
                                    knightsRemove++;
                            }

                            if (IsCellValid(row - 2, col + 1, rows, cols))
                            {
                                if (board[row - 2, col + 1] == 'K')
                                    knightsRemove++;
                            }

                            if (IsCellValid(row + 2, col - 1, rows, cols))
                            {
                                if (board[row + 2, col - 1] == 'K')
                                    knightsRemove++;
                            }

                            if (IsCellValid(row + 2, col + 1, rows, cols))
                            {
                                if (board[row + 2, col + 1] == 'K')
                                    knightsRemove++;
                            }

                            if (IsCellValid(row - 1, col - 2, rows, cols))
                            {
                                if (board[row - 1, col - 2] == 'K')
                                    knightsRemove++;
                            }

                            if (IsCellValid(row + 1, col - 2, rows, cols))
                            {
                                if (board[row + 1, col - 2] == 'K')
                                    knightsRemove++;
                            }

                            if (IsCellValid(row - 1, col + 2, rows, cols))
                            {
                                if (board[row - 1, col + 2] == 'K')
                                    knightsRemove++;
                            }

                            if (IsCellValid(row + 1, col + 2, rows, cols))
                            {
                                if (board[row + 1, col + 2] == 'K')
                                    knightsRemove++;
                            }

                            if (knightsRemove > maxKnightsRemove)
                            {
                                maxKnightsRemove = knightsRemove;
                                rowAndColsToRemove[0] = row;
                                rowAndColsToRemove[1] = col;
                            }
                        }
                    }
                }

                if (maxKnightsRemove == 0)
                    break;

                else
                { 
                    board[rowAndColsToRemove[0], rowAndColsToRemove[1]] = '0';
                    result++;
                }
            }

            Console.WriteLine(result);
        }

        static bool IsCellValid(int row, int col, int rows, int cols)
        {
            return row >= 0 && col >= 0 && row < rows && col < cols;
        }
    }
}
