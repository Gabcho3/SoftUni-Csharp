using System;
using System.Linq;

namespace T04._MatrixShuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                string[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < size[1]; col++)
                    matrix[row, col] = arr[col];
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                if (command[0] != "swap" || command.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                int row1 = int.Parse(command[1]);
                int col1 = int.Parse(command[2]);
                int row2 = int.Parse(command[3]);
                int col2 = int.Parse(command[4]);

                if (row1 < 0 || row2 < 0 || col1 < 0 || col2 < 0 
                    || row1 >= size[0] || row2 >= size[0] || col1 >= size[1] || col2 >= size[1])
                {
                    Console.WriteLine("Invalid input!");
                }

                else
                {
                    string currValue1 = matrix[row1, col1];
                    string currValue2 = matrix[row2, col2];

                    matrix[row1, col1] = currValue2;
                    matrix[row2, col2] = currValue1;

                    int count = 0;
                    foreach (var value in matrix)
                    {
                        count++;
                        Console.Write(value + " ");

                        if (count % matrix.GetLength(1) == 0)
                            Console.WriteLine();
                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
