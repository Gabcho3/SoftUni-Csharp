using System;

namespace T05.ChallengeTheWedding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());

            for(int man = 1; man <= men; man++)
            {
                int table = 0;
                bool noTables = false;
                for(int woman = 1; woman <= women; woman++)
                {
                    Console.Write($"({man} <-> {woman}) ");
                    table++;
                    if (table == tables)
                    {
                        noTables = true;
                        break;
                    }
                }
                if(noTables)
                {
                    break;
                }
            }
        }
    }
}
