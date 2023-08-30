namespace _02._Mouse_In_The_Kitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCows = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowAndCows[0];
            int cols = rowAndCows[1];
            char[,] cupboard = new char[rows, cols];

            int mouseRow = 0;
            int mouseCol = 0;
            int totalCheese = 0;

            for (int row = 0; row < rows; row++)
            {
                string rowContent = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    char currElement = rowContent[col];

                    if (currElement == 'M')
                    {
                        mouseRow = row;
                        mouseCol = col;
                        currElement = '*';
                    }

                    else if (currElement == 'C')
                    {
                        totalCheese++;
                    }

                    cupboard[row, col] = currElement;
                }
            }

            int cheeseEaten = 0;
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "danger")
                {
                    cupboard[mouseRow, mouseCol] = 'M';
                    Console.WriteLine("Mouse will come back later!");
                    break;
                }

                int lastMouseRow = mouseRow;
                int lastMouseCol = mouseCol;
                switch (command)
                {
                    case "up":
                        mouseRow--;
                        break;
                    case "right":
                        mouseCol++;
                        break;
                    case "down":
                        mouseRow++;
                        break;
                    case "left":
                        mouseCol--;
                        break;
                }

                if (OutsideBounds(rows, cols, mouseRow, mouseCol))
                {
                    cupboard[lastMouseRow, lastMouseCol] = 'M';
                    Console.WriteLine("No more cheese for tonight!");
                    break;
                }

                char mousePosition = cupboard[mouseRow, mouseCol];

                if (mousePosition == '@')
                {
                    mouseRow = lastMouseRow;
                    mouseCol = lastMouseCol;
                    continue;
                }

                cupboard[mouseRow, mouseCol] = 'M';
                cupboard[lastMouseRow, lastMouseCol] = '*';

                if (mousePosition == 'C')
                {
                    cheeseEaten++;

                    if (totalCheese == cheeseEaten)
                    {
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        break;
                    }
                }

                if (mousePosition == 'T')
                {
                    Console.WriteLine("Mouse is trapped!");
                    break;
                }
            }

            PrintMatrix(cupboard);
        }

        static bool OutsideBounds(int rows, int cols, int mouseRow, int mouseCol)
        {
            return mouseRow < 0 || mouseCol < 0 || mouseRow >= rows || mouseCol >= cols;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}