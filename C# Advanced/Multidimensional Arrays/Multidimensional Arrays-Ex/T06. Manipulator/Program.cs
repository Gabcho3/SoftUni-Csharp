using System;
using System.Linq;

namespace T06._Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jagged = new int[n][];

            for (int row = 0; row < n; row++)
                jagged[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            for (int row = 0; row < jagged.GetLength(0) - 1; row++)
            {
                bool divide = true;
                int length = 0;

                if (jagged[row].Length == jagged[row + 1].Length)
                    divide = false;

                for (int col = 0; col < jagged[row].Length || col < jagged[row + 1].Length; col++)
                {
                    if (divide)
                    {
                        if (col < jagged[row].Length)
                            jagged[row][col] /= 2;

                        if (col < jagged[row + 1].Length)
                            jagged[row + 1][col] /= 2;
                    }

                    else
                    {
                        if (col < jagged[row].Length)
                            jagged[row][col] *= 2;

                        if (col < jagged[row + 1].Length)
                            jagged[row + 1][col] *= 2;
                    }
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split(" ");
                int row = int.Parse(info[1]);
                int col = int.Parse(info[2]);
                int value = int.Parse(info[3]);

                if (row >= 0 && row < n && col >= 0 && col < jagged[row].Length)
                {
                    switch (info[0])
                    {
                        case "Add":
                            jagged[row][col] += value;
                            break;

                        case "Subtract":
                            jagged[row][col] -= value;
                            break;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                    Console.Write(jagged[i][j] + " ");

                Console.WriteLine();
            }
        }
    }
}
