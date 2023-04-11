using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            char[,] raceRoute = new char[size, size];

            Dictionary<int, int> tunnelsPositions = new Dictionary<int, int>();
            for (int row = 0; row < size; row++)
            {
                char[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    char currElement = rowData[col];
                    if (currElement == 'T')
                    {
                        tunnelsPositions.Add(row, col);
                    }

                    raceRoute[row, col] = currElement;
                }
            }

            int carRow = 0;
            int carCol = 0;
            int kilometersPassed = 0;

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End")
                {
                    Console.WriteLine($"Racing car {racingNumber} DNF.");
                    break;
                }

                switch (cmd)
                {
                    case "up": carRow--; break;
                    case "right": carCol++; break;
                    case "down": carRow++; break;
                    case "left": carCol--; break;
                }

                if (raceRoute[carRow, carCol] == '.')
                    kilometersPassed += 10;

                else if (raceRoute[carRow, carCol] == 'F')
                {
                    kilometersPassed += 10;
                    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                    break;
                }

                else if (tunnelsPositions.ContainsKey(carRow))
                {
                    if (tunnelsPositions[carRow] == carCol)
                    {
                        kilometersPassed += 30;
                        carRow = tunnelsPositions.FirstOrDefault(k => k.Key != carRow).Key;
                        carCol = tunnelsPositions[carRow];
                        RemovingTunnels(tunnelsPositions, raceRoute);
                    }
                }
            }
            Console.WriteLine($"Distance covered {kilometersPassed} km.");
            raceRoute[carRow, carCol] = 'C';
            PrintRaceRoute(raceRoute);
        }

        private static void PrintRaceRoute(char[,] raceRoute)
        {
            for (int row = 0; row < raceRoute.GetLength(0); row++)
            {
                for (int col = 0; col < raceRoute.GetLength(0); col++)
                {
                    Console.Write(raceRoute[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void RemovingTunnels(Dictionary<int, int> tunnelsPositions, char[,] raceRoute)
        {
            foreach (var (row, col) in tunnelsPositions)
            {
                raceRoute[row, col] = '.';
            }
        }
    }
}
