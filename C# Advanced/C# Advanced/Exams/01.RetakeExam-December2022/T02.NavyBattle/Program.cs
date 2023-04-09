namespace T02.NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] battlefield = new char[size, size];

            int subRow = 0;
            int subCol = 0;

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    char elemenet = rowData[col];

                    if (elemenet == 'S')
                    {
                        subRow = row;
                        subCol = col;
                        battlefield[row, col] = '-';
                        continue;
                    }

                    battlefield[row, col] = elemenet;
                }
            }

            int hits = 0;
            int destroyed = 0;
            while (true)
            {
                string cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "up":
                        subRow--;
                        if (OutOfRange(subRow, subCol, size))
                            subRow++;
                        break;

                    case "right":
                        subCol++;
                        if (OutOfRange(subRow, subCol, size))
                            subCol--;
                        break;

                    case "down":
                        subRow++;
                        if (OutOfRange(subRow, subCol, size))
                            subRow--;
                        break;

                    case "left":
                        subCol--;
                        if (OutOfRange(subRow, subCol, size))
                            subCol++;
                        break;
                }

                char currPosition = battlefield[subRow, subCol];

                if (currPosition == '*')
                    hits++;

                else if (currPosition == 'C')
                    destroyed++;

                battlefield[subRow, subCol] = '-';

                if (hits == 3)
                {
                    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{subRow}, {subCol}]!");
                    break;
                }

                if (destroyed == 3)
                {
                    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                    break;
                }
            }
            battlefield[subRow, subCol] = 'S';
            PrintBattlefield(battlefield);
        }

        private static void PrintBattlefield(char[,] battlefield)
        {
            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                for (int col = 0; col < battlefield.GetLength(0); col++)
                {
                    Console.Write(battlefield[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool OutOfRange(int row, int col, int size)
        {
            return row < 0 || row >= size || col < 0 || col >= size;
        }
    }
}