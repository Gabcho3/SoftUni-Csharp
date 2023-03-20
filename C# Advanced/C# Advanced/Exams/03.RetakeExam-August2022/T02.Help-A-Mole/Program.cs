using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Т02.Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            int moleRow = 0;
            int moleCol = 0;
            for (int row = 0; row < n; row++)
            {
                string colElements = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    if (colElements[col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                    field[row, col] = colElements[col];
                }
            }
            field[moleRow, moleCol] = '-';

            List<int[]> specialPlaces = FindSpeacialPlaces(field);
            int points = 0;
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End")
                {
                    Console.WriteLine("Too bad! The Mole lost this battle!");
                    Console.WriteLine($"The Mole lost the game with a total of {points} points.");
                    break;
                }

                switch (cmd)
                {
                    case "left":
                        moleCol--;
                        if (!CheckedCoordinates(n, moleRow, moleCol))
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            moleCol++;
                        }
                        break;
                    case "up":
                        moleRow--;
                        if (!CheckedCoordinates(n, moleRow, moleCol))
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            moleRow++;
                        }
                        break;
                    case "right":
                        moleCol++;
                        if (!CheckedCoordinates(n, moleRow, moleCol))
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            moleCol--;
                        }
                        break;
                    case "down":
                        moleRow++;
                        if (!CheckedCoordinates(n, moleRow, moleCol))
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            moleRow--;
                        }
                        break;
                }
                if (char.IsDigit(field[moleRow, moleCol]))
                {
                    points += int.Parse(field[moleRow, moleCol].ToString());
                    field[moleRow, moleCol] = '-';
                }

                if (field[moleRow, moleCol] == 'S')
                {
                    field[moleRow, moleCol] = '-';

                    int placeRow = specialPlaces.Find(x => x[0] != moleRow || x[1] != moleCol)[0];
                    int placeCol = specialPlaces.Find(x => x[0] != moleRow || x[1] != moleCol)[1];

                    moleRow = placeRow;
                    moleCol = placeCol;

                    field[moleRow, moleCol] = '-';

                    points -= 3;
                }

                if (points >= 25)
                {
                    Console.WriteLine("Yay! The Mole survived another game!");
                    Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
                    break;
                }
            }
            field[moleRow, moleCol] = 'M';
            PrintField(field, n);
        }

        private static void PrintField(char[,] field, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool CheckedCoordinates(int n, int moleRow, int moleCol)
        {
            return moleRow < n && moleRow >= 0 && moleCol < n && moleCol >= 0;
        }

        private static List<int[]> FindSpeacialPlaces(char[,] field)
        {
            List<int[]> coordinates = new List<int[]>();
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'S')
                    {
                        coordinates.Add(new int[2] { row, col });
                    }
                }
            }

            return coordinates;
        }
    }
}
