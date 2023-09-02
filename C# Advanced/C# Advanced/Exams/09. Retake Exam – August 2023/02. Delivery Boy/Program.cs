namespace _02._Delivery_Boy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            char[,] field = new char[rows, cols];

            int firstBoyRow = 0;
            int firstBoyCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    char currElement = rowData[col];

                    if (currElement == 'B')
                    {
                        firstBoyRow = row;
                        firstBoyCol = col;
                    }

                    field[row, col] = currElement;
                }
            }

            int currRow = firstBoyRow;
            int currCol = firstBoyCol;

            while (true)
            {
                string command = Console.ReadLine();
                int lastRow = currRow;
                int lastCol = currCol;

                switch (command)
                {
                    case "up":
                        currRow--;
                        break;

                    case "down":
                        currRow++;
                        break;

                    case "left":
                        currCol--;
                        break;

                    case "right":
                        currCol++;
                        break;
                }

                if (IsOutsideBounds(rows, cols, currRow, currCol))
                {
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    field[firstBoyRow, firstBoyCol] = ' ';
                    break;
                }

                char currElement = field[currRow, currCol];

                if (currElement == 'A')
                {
                    field[currRow, currCol] = 'P';
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }

                switch (currElement)
                {
                    case '-':
                    case '.':
                        field[currRow, currCol] = '.';
                        break;

                    case 'P':
                        field[currRow, currCol] = 'R';
                        Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                        break;

                    case '*':
                        currRow = lastRow;
                        currCol = lastCol;
                        break;
                }
            }

            PrintField(field);
        }

        public static bool IsOutsideBounds(int rows, int cols, int row, int col)
        {
            return row >= rows || row < 0 || col >= cols || col < 0;
        }

        public static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}