using System;
using System.Drawing;
using System.Linq;

namespace T02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] forest = new char[size, size];

            for(int row = 0; row < size; row++)
            {
                char[] colValue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for(int col = 0; col < size; col++)
                {
                    forest[row, col] = colValue[col];
                }
            }

            string[] cmd;
            int blackCount = 0;
            int whiteCount = 0;
            int summerCount = 0;
            int boarTruffles = 0;
            while(true)
            {
                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmd[0] == "Stop")
                {
                    break;
                }

                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);

                switch (cmd[0])
                {
                    case "Collect":
                        char value = forest[row, col];

                        if (value == 'B')
                            blackCount++;

                        else if (value == 'W')
                            whiteCount++;

                        else if (value == 'S')
                            summerCount++;

                        forest[row, col] = '-';
                        break;

                    case "Wild_Boar":
                        string direction = (cmd[3]);
                        boarTruffles = BoarMovement(forest, row, col, direction, boarTruffles);
                        break;
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackCount} black, {summerCount} summer, and {whiteCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTruffles} truffles.");
            PrintForest(forest, size);
        }

        private static void PrintForest(char[,] forest, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(forest[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int BoarMovement(char[,] forest, int row, int col, string direction, int boarTruffles)
        {
            if (direction == "up")
            {
                for(int r = row; r >= 0; r -= 2)
                {
                    if (forest[r, col] == 'B' || forest[r, col] == 'W' || forest[r, col] == 'S')
                    {
                        boarTruffles++;
                        forest[r, col] = '-';
                    }
                }
            }

            else if(direction == "down")
            {
                for (int r = row; r < forest.GetLength(0); r += 2)
                {
                    if (forest[r, col] == 'B' || forest[r, col] == 'W' || forest[r, col] == 'S')
                    {
                        boarTruffles++;
                        forest[r, col] = '-';
                    }
                }
            }

            else if (direction == "left")
            {
                for (int c = col; c >= 0; c -= 2)
                {
                    if (forest[row, c] == 'B' || forest[row, c] == 'W' || forest[row, c] == 'S')
                    {
                        boarTruffles++; 
                        forest[row, c] = '-';
                    }
                }
            }

            else
            {
                for (int c = col; c < forest.GetLength(1); c += 2)
                {
                    if (forest[row, c] == 'B' || forest[row, c] == 'W' || forest[row, c] == 'S')
                    {
                        boarTruffles++;
                        forest[row, c] = '-';
                    }
                }
            }

            return boarTruffles;
        }
    }
}
