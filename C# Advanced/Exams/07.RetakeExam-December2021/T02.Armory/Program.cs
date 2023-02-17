using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] armory = new char[size, size];

            int officerRow = 0, officerCol = 0;
            List<int[]> mirrorPositions = new List<int[]>();
            for (int row = 0; row < size; row++)
            {
                string colValue = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    armory[row, col] = colValue[col];

                    if (armory[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                        armory[row, col] = '-';
                    }

                    else if (armory[row, col] == 'M')
                    {
                        mirrorPositions.Add(new int[2] { row, col });
                        armory[row, col] = '-';
                    }
                }
            }

            int coinsPaid = 0;
            bool isOnMirror = false;
            while (true)
            {
                string cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "up":
                        officerRow--;
                        break;

                    case "right":
                        officerCol++;
                        break;

                    case "down":
                        officerRow++;
                        break;

                    case "left":
                        officerCol--;
                        break;
                }

                if (OutOfArmory(officerRow, officerCol, size))
                {
                    Console.WriteLine("I do not need more swords!");
                    break;
                }

                if (char.IsDigit(armory[officerRow, officerCol]))
                {
                    coinsPaid += int.Parse(armory[officerRow, officerCol].ToString());
                    armory[officerRow, officerCol] = '-';
                }

                var onMirror = mirrorPositions.Find(x => x[0] == officerRow && x[1] == officerCol);

                if (onMirror != null)
                {
                    int[] indexes = mirrorPositions.Find(x => x[0] != officerRow && x[1] != officerCol);
                    officerRow = indexes[0];
                    officerCol = indexes[1];
                }

                if (coinsPaid >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    armory[officerRow, officerCol] = 'A';
                    break;
                }
            }
            Console.WriteLine($"The king paid {coinsPaid} gold coins.");
            PrintArmory(armory, size);
        }

        private static void PrintArmory(char[,] armory, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(armory[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool OutOfArmory(int row, int col, int size)
        {
            return row < 0 || row >= size || col < 0 || col >= size;
        }
    }
}
