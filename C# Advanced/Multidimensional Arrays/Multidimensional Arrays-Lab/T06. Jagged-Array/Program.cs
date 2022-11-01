using System;
using System.Linq;

namespace T06._Jagged_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];


            for (int row = 0; row < rows; row++)
                jagged[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "END")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if(row > jagged.Length - 1 || row < 0)
                    Console.WriteLine("Invalid coordinates");

                else
                {
                    if (col > jagged[row].Length - 1 || col < 0)
                        Console.WriteLine("Invalid coordinates");

                    else
                    {
                        switch (command[0])
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

                command = Console.ReadLine().Split();
            }

            foreach (var arr in jagged)
                Console.WriteLine(string.Join(" ", arr));
        }
    }
}
