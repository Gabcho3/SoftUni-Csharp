using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace T02.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] pond = new char[size, size];

            int beaverRow = 0;
            int beaverCol = 0;
            int totalBranches = 0;
            for (int row = 0; row < size; row++)
            {
                char[] colValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = colValues[col];

                    if (pond[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                        pond[row, col] = '-';
                    }

                    if (IsLower(pond[row, col]))
                    {
                        totalBranches++;
                    }
                }
            }

            List<char> allBranchesColected = new List<char>();
            List<char> branchesColected = new List<char>();
            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "end")
                {
                    Console.WriteLine($"The Beaver failed to collect every wood branch. " +
                        $"There are {totalBranches - allBranchesColected.Count} branches left.");
                    break;
                }

                switch (cmd)
                {
                    case "up":
                        beaverRow--;
                        if (!CheckIndex(size, beaverRow, beaverCol))
                        {
                            beaverRow++;
                            if (branchesColected.Count > 0 && allBranchesColected.Count > 0 )
                                branchesColected.RemoveAt(branchesColected.Count - 1);
                        }
                        break;

                    case "right":
                        beaverCol++;
                        if (!CheckIndex(size, beaverRow, beaverCol))
                        {
                            beaverCol--;
                            if (branchesColected.Count > 0 && allBranchesColected.Count > 0)
                                branchesColected.RemoveAt(branchesColected.Count - 1);
                        }
                        break;

                    case "down":
                        beaverRow++;
                        if (!CheckIndex(size, beaverRow, beaverCol))
                        {
                            beaverRow--;
                            if (branchesColected.Count > 0 && allBranchesColected.Count > 0)
                                branchesColected.RemoveAt(branchesColected.Count - 1);
                        }
                        break;

                    case "left":
                        beaverCol--;
                        if (!CheckIndex(size, beaverRow, beaverCol))
                        {
                            beaverCol++;
                            if (branchesColected.Count > 0 && allBranchesColected.Count > 0)
                                branchesColected.RemoveAt(branchesColected.Count - 1);
                        }
                        break;
                }

                if (pond[beaverRow, beaverCol] == 'F')
                {
                    pond[beaverRow, beaverCol] = '-';
                    if (InLastIndex(beaverRow, beaverCol, size))
                    {
                        int[] indexes = MoveOpositeToEnd(beaverRow, beaverCol, cmd, size);
                        beaverRow = indexes[0];
                        beaverCol = indexes[1];
                    }

                    else
                    {
                        int[] indexes = MoveToEnd(beaverRow, beaverCol, cmd, size);
                        beaverRow = indexes[0];
                        beaverCol = indexes[1];
                    }
                }

                if (IsLower(pond[beaverRow, beaverCol]))
                {
                    allBranchesColected.Add(pond[beaverRow, beaverCol]);
                    branchesColected.Add(pond[beaverRow, beaverCol]);
                    pond[beaverRow, beaverCol] = '-';
                }

                if(totalBranches == allBranchesColected.Count)
                {
                    Console.WriteLine($"The Beaver successfully collect {branchesColected.Count} wood branches: " +
                        $"{string.Join(", ", branchesColected)}.");
                    break;
                }
            }
            pond[beaverRow, beaverCol] = 'B';
            PrintPond(pond, size);
        }

        private static void PrintPond(char[,] pond, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(pond[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[] MoveOpositeToEnd(int beaverRow, int beaverCol, string cmd, int size)
        {
            switch (cmd)
            {
                case "up":
                    beaverRow = size - 1;
                    break;

                case "right":
                    beaverCol = 0;
                    break;

                case "down":
                    beaverRow = 0;
                    break;

                case "left":
                    beaverCol = size - 1;
                    break;
            }

            return new int[2] { beaverRow, beaverCol };
        }

        private static int[] MoveToEnd(int beaverRow, int beaverCol, string cmd, int size)
        {
            switch (cmd)
            {
                case "up":
                    beaverRow = 0;
                    break;

                case "right":
                    beaverCol = size - 1;
                    break;

                case "down":
                    beaverRow = size - 1;
                    break;

                case "left":
                    beaverCol = 0;
                    break;
            }

            return new int[2] { beaverRow, beaverCol };
        }

        private static bool InLastIndex(int beaverRow, int beaverCol, int size)
            => beaverRow == 0 && beaverCol == 0 || beaverCol == size - 1; 

        private static bool IsLower(char ch)
            => ch >= 97 && ch <= 122;

        private static bool CheckIndex(int size, int beaverRow, int beaverCol)
            => beaverRow >= 0 && beaverRow < size && beaverCol >= 0 && beaverCol < size;
    }
}
