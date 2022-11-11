using System;
using System.Linq;

namespace T10._Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] lair = new char[size[0], size[1]];

            int rowOfPlayer = 0;
            int colOfPlayer = 0;

            for (int row = 0; row < size[0]; row++)
            {
                string arr = Console.ReadLine();

                for (int col = 0; col < size[1]; col++)
                {
                    lair[row, col] = arr[col];

                    if (arr[col] == 'P')
                    {
                        rowOfPlayer = row;
                        colOfPlayer = col;
                    }
                }
            }

            string commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                char ch = commands[i];

                lair[rowOfPlayer, colOfPlayer] = '.';

                if (ch == 'U')
                    rowOfPlayer--;

                else if (ch == 'R')
                    colOfPlayer++;

                else if (ch == 'D')
                    rowOfPlayer++;

                else
                    colOfPlayer--;

                bool won = false;

                if (rowOfPlayer < 0 || colOfPlayer < 0 || rowOfPlayer >= size[0] || colOfPlayer >= size[1])
                    won = true;

                else
                    lair[rowOfPlayer, colOfPlayer] = 'P';

                bool lost = false;

                char[,] newLair = CopyMatrix(lair);

                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row, col] == 'B')
                        {
                            if (row - 1 >= 0)
                            {
                                if (lair[row - 1, col] == 'P')
                                    lost = true;

                                newLair[row - 1, col] = 'B';
                            }

                            if (col - 1 >= 0)
                            {
                                if (lair[row, col - 1] == 'P')
                                    lost = true;

                                newLair[row, col - 1] = 'B';
                            }

                            if (row + 1 < size[0])
                            {
                                if (lair[row + 1, col] == 'P')
                                    lost = true;

                                newLair[row + 1, col] = 'B';
                            }

                            if (col + 1 < size[1])
                            {
                                if (lair[row, col + 1] == 'P')
                                    lost = true;

                                newLair[row, col + 1] = 'B';
                            }
                        }
                    }
                }

                lair = newLair;

                if (won)
                {
                    if (rowOfPlayer < 0)
                        rowOfPlayer = 0;

                    if (colOfPlayer < 0)
                        colOfPlayer = 0;

                    if (rowOfPlayer >= size[0])
                        rowOfPlayer = size[0] - 1;

                    if (colOfPlayer >= size[1])
                        colOfPlayer = size[1] - 1;

                    int count = 0;
                    foreach (var value in lair)
                    {
                        count++;
                        Console.Write(value);

                        if (count % size[1] == 0)
                            Console.WriteLine();
                    }

                    Console.WriteLine($"won: {rowOfPlayer} {colOfPlayer}");
                    return;
                }

                if (lost)
                {
                    int count = 0;
                    foreach (var value in lair)
                    {
                        count++;
                        Console.Write(value);

                        if (count % size[1] == 0)
                            Console.WriteLine();
                    }

                    Console.WriteLine($"dead: {rowOfPlayer} {colOfPlayer}");
                    return;
                }
            }
        }

        static char[,] CopyMatrix(char[,] lair)
        {
            char[,] newLair = new char[lair.GetLength(0), lair.GetLength(1)];

            for(int row = 0; row < lair.GetLength(0); row++)
                for(int col = 0; col < lair.GetLength(1); col++)
                    newLair[row, col] = lair[row, col];

            return newLair;
        }
    }
}
