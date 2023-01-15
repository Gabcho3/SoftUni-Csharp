using System;
using System.Collections.Generic;
using System.Linq;

namespace T10._Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            char[][] lair = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                lair[row] = Console.ReadLine().ToCharArray();
            }

            int[] playerCoordinates = FindPlayerCoordinates(lair, rows, cols);
            int playerRow = playerCoordinates[0];
            int playerCol = playerCoordinates[1];
            lair[playerRow][playerCol] = '.';

            string commands = Console.ReadLine();

            MovePlayer(commands, playerRow, playerCol, lair);
        }

        private static void MovePlayer(string? commands, int playerRow, int playerCol, char[][] lair)
        {

            for (int i = 0; i < commands.Length; i++)
            {
                char currCommand = commands[i];

                if (currCommand == 'U')
                {
                    if (CheckCoordinates(playerRow - 1, playerCol, lair))
                    {
                        playerRow--;
                    }

                    else
                    {
                        FindBunniesLocation(lair);

                        if (lair[playerRow][playerCol] != 'B')
                        {
                            PrintingLair(lair);
                            Console.WriteLine("won: {0} {1}", playerRow, playerCol);
                            return;
                        }
                    }
                }

                if (currCommand == 'R')
                {
                    if (CheckCoordinates(playerCol, playerCol + 1, lair))
                    {
                        playerCol++;
                    }

                    else
                    {
                        FindBunniesLocation(lair);

                        if (lair[playerRow][playerCol] != 'B')
                        {
                            PrintingLair(lair);
                            Console.WriteLine("won: {0} {1}", playerRow, playerCol);
                            return;
                        }
                    }
                }

                if (currCommand == 'D')
                {
                    if (CheckCoordinates(playerRow + 1, playerCol, lair))
                    {
                        playerRow++;
                    }

                    else
                    {
                        FindBunniesLocation(lair);

                        if (lair[playerRow][playerCol] != 'B')
                        {
                            PrintingLair(lair);
                            Console.WriteLine("won: {0} {1}", playerRow, playerCol);
                            return;
                        }
                    }
                }

                if (currCommand == 'L')
                {
                    if (CheckCoordinates(playerRow, playerCol - 1, lair))
                    {
                        playerCol--;
                    }

                    else
                    {
                        FindBunniesLocation(lair);

                        if (lair[playerRow][playerCol] != 'B')
                        {

                            PrintingLair(lair);
                            Console.WriteLine("won: {0} {1}", playerRow, playerCol);
                            return;
                        }
                    }
                }

                FindBunniesLocation(lair);

                if (lair[playerRow][playerCol] == 'B')
                {
                    PrintingLair(lair);
                    Console.WriteLine("dead: {0} {1}", playerRow, playerCol);
                    return;
                }
            }
        }

        private static void FindBunniesLocation(char[][] lair)
        {
            List<int[]> coordinatesOfBunnies = new List<int[]>();

            for (int r = 0; r < lair.GetLength(0); r++)
            {
                for (int c = 0; c < lair[r].Length; c++)
                {
                    if (lair[r][c] == 'B')
                    {
                        coordinatesOfBunnies.Add(new int[] { r, c });
                    }
                }
            }

            MultiplyBunnies(coordinatesOfBunnies, lair);
        }

        private static void MultiplyBunnies(List<int[]> coordinatesOfBunnies, char[][] lair)
        {
            List<int[]> coordinatesToMuliply = new List<int[]>();
            for (int i = 0; i < coordinatesOfBunnies.Count; i++)
            {
                int row = coordinatesOfBunnies[i][0];
                int col = coordinatesOfBunnies[i][1];

                if (CheckCoordinates(row - 1, col, lair))
                {
                    coordinatesToMuliply.Add(new int[] { row - 1, col });
                }

                if (CheckCoordinates(row + 1, col, lair))
                {
                    coordinatesToMuliply.Add(new int[] { row + 1, col });
                }

                if (CheckCoordinates(row, col - 1, lair))
                {
                    coordinatesToMuliply.Add(new int[] { row, col - 1 });
                }

                if (CheckCoordinates(row, col + 1, lair))
                {
                    coordinatesToMuliply.Add(new int[] { row, col + 1 });
                }
            }

            for (int i = 0; i < coordinatesToMuliply.Count; i++)
            {
                int row = coordinatesToMuliply[i][0];
                int col = coordinatesToMuliply[i][1];

                lair[row][col] = 'B';
            }
        }

        private static void PrintingLair(char[][] lair)
        {
            foreach (var col in lair)
            {
                foreach (var element in col)
                {
                    Console.Write(element);
                }
                Console.WriteLine();
            }
        }

        private static bool CheckCoordinates(int playerRow, int playerCol, char[][] lair)
        {
            if (playerRow >= 0 && playerRow < lair.GetLength(0))
            {
                if (playerCol >= 0 && playerCol < lair[playerRow].Length)
                    return true;
            }

            return false;
        }

        private static int[] FindPlayerCoordinates(char[][] lair, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (lair[row][col] == 'P')
                    {
                        return new int[] { row, col };
                    }
                }
            }

            return new int[] { };
        }
    }
}
