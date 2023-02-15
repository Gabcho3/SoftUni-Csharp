using System;

namespace T02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] wall = new char[size, size];
            int handymanRow = 0;
            int handymanCol = 0;

            for (int row = 0; row < size; row++)
            {
                string rowValue = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    if (rowValue[col] == 'V')
                    {
                        handymanRow = row;
                        handymanCol = col;
                        wall[row, col] = '*';
                    }

                    else
                        wall[row, col] = rowValue[col];
                }
            }

            int countOfHoles = 1;
            int countOfRods = 0;
            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End")
                {
                    Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
                    wall[handymanRow, handymanCol] = 'V';
                    break;
                }

                int lastRow = handymanRow;
                int lastCol = handymanCol;
                switch (cmd)
                {
                    case "left":
                        handymanCol--;
                        if (!CheckPosition(size, handymanRow, handymanCol))
                        {
                            handymanCol++;
                            continue;
                        }

                        break;

                    case "up":
                        handymanRow--;
                        if (!CheckPosition(size, handymanRow, handymanCol))
                        {
                            handymanRow++;
                            continue;
                        }

                        break;

                    case "right":
                        handymanCol++;
                        if (!CheckPosition(size, handymanRow, handymanCol))
                        {
                            handymanCol--;
                            continue;
                        }

                        break;

                    case "down":
                        handymanRow++;
                        if (!CheckPosition(size, handymanRow, handymanCol))
                        {
                            handymanRow--;
                            continue;
                        }
                            break;
                }

                char value = wall[handymanRow, handymanCol];

                if (value == 'R')
                {
                    handymanRow = lastRow;
                    handymanCol = lastCol;
                    countOfRods++;
                    Console.WriteLine("Vanko hit a rod!");
                }

                else if (value == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{handymanRow}, {handymanCol}]!");
                }

                else if (value == 'C')
                {
                    wall[handymanRow, handymanCol] = 'E';
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {++countOfHoles} hole(s).");
                    break;
                }

                else
                {
                    countOfHoles++;
                    wall[handymanRow, handymanCol] = '*';
                }
            }
            PrintWall(wall, size);
        }

        private static void PrintWall(char[,] wall, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(wall[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool CheckPosition(int size, int handymanRow, int handymanCol)
        {
            return handymanRow >= 0 && handymanRow < size && handymanCol >= 0 && handymanCol < size;
        }
    }
}
