using System;
using System.Linq;

namespace T02.BlindMan_sBuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            char[,] playground = new char[rows, cols];
            int currRow = 0;
            int currCol = 0;
            int totalOpponents = 0;
            for (int row = 0; row < rows; row++)
            {
                char[] colValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    playground[row, col] = colValues[col];

                    if (playground[row, col] == 'B')
                    {
                        currRow = row;
                        currCol = col;
                        playground[row, col] = '-';
                    }

                    if (playground[row, col] == 'P')
                        totalOpponents++;
                }
            }

            int playersTouched = 0;
            int movesMade = 0;
            while (true)
            {
                string cmd = Console.ReadLine();
                bool noMove = false;
                if (playersTouched == totalOpponents || cmd == "Finish")
                {
                    break;
                }

                switch (cmd)
                {
                    case "up":
                        currRow--;
                        if (InvalidIndex(currRow, currCol, rows, cols) || InFrontOfObstacle(playground, currRow, currCol))
                        {
                            currRow++;
                            noMove = true;
                        }
                        break;

                    case "right":
                        currCol++;
                        if (InvalidIndex(currRow, currCol, rows, cols) || InFrontOfObstacle(playground, currRow, currCol))
                        {
                            currCol--;
                            noMove = true;
                        }
                        break;

                    case "down":
                        currRow++;
                        if (InvalidIndex(currRow, currCol, rows, cols) || InFrontOfObstacle(playground, currRow, currCol))
                        {
                            currRow--;
                            noMove = true;
                        }
                        break;

                    case "left":
                        currCol--;
                        if (InvalidIndex(currRow, currCol, rows, cols) || InFrontOfObstacle(playground, currRow, currCol))
                        {
                            currCol++;
                            noMove = true;
                        }
                        break;
                }

                if (playground[currRow, currCol] == '-' && !noMove)
                {
                    movesMade++;
                }

                else if (playground[currRow, currCol] == 'P')
                {
                    playersTouched++;
                    playground[currRow, currCol] = '-';
                    movesMade++;
                }
            }
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {playersTouched} Moves made: {movesMade}");
        }

        private static bool InFrontOfObstacle(char[,] playground, int row, int col)
        {
            return playground[row, col] == 'O';
        }

        private static bool InvalidIndex(int startRow, int startCol, int rows, int cols)
        {
            return startRow < 0 || startRow >= rows || startCol < 0 || startCol >= cols;
        }
    }
}
