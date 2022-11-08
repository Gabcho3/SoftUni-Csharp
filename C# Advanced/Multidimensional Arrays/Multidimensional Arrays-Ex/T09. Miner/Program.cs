using System;
using System.ComponentModel.Design;
using System.Linq;

namespace T09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            char[,] field = new char[rows, cols];

            string[] commands = Console.ReadLine().Split();

            int totalCoals = 0;
            int currRow = 0;
            int currCol = 0;
            for (int row = 0; row < rows; row++)
            {
                char [] values = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = values[col];

                    if (values[col] == 'c')
                        totalCoals++;

                    if (values[col] == 's')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
                    
            }

            int coalsCount = 0;
            for (int i = 0; i < commands.Length; i++)
            {
                string currCommand = commands[i];

                field[currRow, currCol] = '*';

                if (currCommand == "up" && currRow - 1 >= 0)
                    currRow -= 1;

                else if (currCommand == "right" && currCol + 1 < field.GetLength(1))
                    currCol += 1;

                else if (currCommand == "down" && currRow + 1 < field.GetLength(0))
                    currRow += 1;

                else if (currCommand == "left" && currCol - 1 >= 0)
                    currCol -= 1;

                if (field[currRow, currCol] == 'c')
                    coalsCount++;

                else if (field[currRow, currCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({currRow}, {currCol})");
                    return;
                }

                else
                    continue;

                if (coalsCount == totalCoals)
                {
                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                    return;
                }
            }

            Console.WriteLine($"{totalCoals - coalsCount} coals left. ({currRow}, {currCol})");
        }
    }
}