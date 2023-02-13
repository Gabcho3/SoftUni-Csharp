using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            char[,] route = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    route[row, col] = values[col];
                }
            }

            int carRow = 0;
            int carCol = 0;
            int km = 0;
            List<int[]> tunnelPositions = FindTunnels(route);

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End")
                {
                    Console.WriteLine($"Racing car {racingNumber} DNF.");
                    Console.WriteLine($"Distance covered {km} km.");
                    route[carRow, carCol] = 'C';
                    PrintingRoute(route);
                    return;
                }

                if (cmd == "left")
                {
                    carCol--;
                }

                else if (cmd == "up")
                {
                    carRow--;
                }

                else if (cmd == "right")
                {
                    carCol++;
                }

                else if (cmd == "down")
                {
                    carRow++;
                }

                if (tunnelPositions.Any(x => x[0] == carRow && x[1] == carCol))
                {
                    int[] endOfTunnel = tunnelPositions.Find(x => x[0] != carRow || x[1] != carCol);
                    carRow = endOfTunnel[0];
                    carCol = endOfTunnel[1];

                    route[tunnelPositions[0][0], tunnelPositions[0][1]] = '.';
                    route[tunnelPositions[1][0], tunnelPositions[1][1]] = '.';

                    km += 20; //we always add 10kms
                }
                km += 10;

                if (route[carRow, carCol] == 'F')
                {
                    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                    Console.WriteLine($"Distance covered {km} km.");
                    route[carRow, carCol] = 'C';
                    PrintingRoute(route);
                    return;
                }
            }
        }

        private static void PrintingRoute(char[,] route)
        {
            for (int i = 0; i < route.GetLength(0); i++)
            {
                for (int j = 0; j < route.GetLength(1); j++)
                {
                    Console.Write(route[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static List<int[]> FindTunnels(char[,] route)
        {
            List<int[]> coordinates = new List<int[]>();
            for (int i = 0; i < route.GetLength(0); i++)
            {
                for (int j = 0; j < route.GetLength(1); j++)
                {
                    if (route[i, j] == 'T')
                    {
                        coordinates.Add(new int[2] { i, j });
                    }
                }
            }

            return coordinates;
        }
    }
}
