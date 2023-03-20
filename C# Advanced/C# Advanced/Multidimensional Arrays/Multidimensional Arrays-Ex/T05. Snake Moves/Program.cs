using System;
using System.Linq;

namespace T05._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string snake = Console.ReadLine();

            char[,] stairs = new char[sizes[0], sizes[1]];
            int index = 0;

            for (int row = 0; row < sizes[0]; row++)
            {
                if ((row + 1) % 2 != 0)
                {
                    for (int col = 0; col < sizes[1]; col++)
                    {
                        stairs[row, col] = snake[index++];

                        if (index >= snake.Length)
                            index = 0;
                    }
                }

                else
                {
                    for (int col = sizes[1] - 1; col >= 0; col--)
                    {
                        stairs[row, col] = snake[index++];

                        if (index >= snake.Length)
                            index = 0;
                    }
                }
            }

            int count = 0;
            foreach (var ch in stairs)
            {
                count++;
                Console.Write(ch);

                if (count % sizes[1] == 0)
                    Console.WriteLine();
            }
        }
    }
}
