namespace T02.NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] battlefield = new string[size, size];

            for (int row = 0; row < size; row++)
            {
                string rowValues = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    battlefield[row, col] = rowValues[col].ToString();
                }
            }

            int[] coordinates = FindSubmarinePosition(battlefield);
            int subRow = coordinates[0];
            int subCol = coordinates[1];
            battlefield[subRow, subCol] = "-"; //we will move submarine

            int mineHits = 0;
            int targetHits = 0;

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "up")
                {
                    if (CheckCoordinates(battlefield, --subRow, subCol))
                    {
                        if (battlefield[subRow, subCol] == "*")
                            mineHits++;

                        else if (battlefield[subRow, subCol] == "C")
                            targetHits++;

                        battlefield[subRow, subCol] = "-";
                    }

                    else
                        subRow++;
                }

                else if (cmd == "right")
                {
                    if (CheckCoordinates(battlefield, subRow, ++subCol))
                    {
                        if (battlefield[subRow, subCol] == "*")
                            mineHits++;

                        else if (battlefield[subRow, subCol] == "C")
                            targetHits++;

                        battlefield[subRow, subCol] = "-";
                    }

                    else
                        subCol++;
                }

                else if (cmd == "down")
                {
                    if (CheckCoordinates(battlefield, ++subRow, subCol))
                    {
                        if (battlefield[subRow, subCol] == "*")
                            mineHits++;

                        else if (battlefield[subRow, subCol] == "C")
                            targetHits++;

                        battlefield[subRow, subCol] = "-";
                    }

                    else
                        subRow--;
                }

                else if (cmd == "left")
                {
                    if (CheckCoordinates(battlefield, subRow, --subCol))
                    {
                        if (battlefield[subRow, subCol] == "*")
                            mineHits++;

                        else if (battlefield[subRow, subCol] == "C")
                        {
                            targetHits++;
                        }

                        battlefield[subRow, subCol] = "-";
                    }

                    else
                        subCol++;
                }

                if (mineHits == 3)
                {
                    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{subRow}, {subCol}]!");
                    battlefield[subRow, subCol] = "S";//we are printing battlefield
                    PrintBattlefield(battlefield);
                    return;
                }

                if (targetHits == 3)
                {
                    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                    battlefield[subRow, subCol] = "S";//we are printing battlefield
                    PrintBattlefield(battlefield);
                    return;
                }
            }
        }

        private static void PrintBattlefield(string[,] battlefield)
        {
            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                for (int col = 0; col < battlefield.GetLength(1); col++)
                {
                    Console.Write(battlefield[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool CheckCoordinates(string[,] wall, int subRow, int subCol)
        {
            return subRow < wall.GetLength(0) && subCol < wall.GetLength(1);
        }

        private static int[] FindSubmarinePosition(string[,] wall)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    if (wall[row, col] == "S")
                        return new int[2] { row, col };
                }
            }

            return new int[2];
        }
    }
}