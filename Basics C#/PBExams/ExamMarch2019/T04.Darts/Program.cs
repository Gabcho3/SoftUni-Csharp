using System;

namespace T04.Darts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string type = "";
            int pointsToReach = 301;
            int successful = 0;
            int unsuccessful = 0;

            while (true)
            {
                type = Console.ReadLine();
                if(type == "Retire")
                {
                    break;
                }

                int points = int.Parse(Console.ReadLine());

                if (type == "Single")
                {
                    pointsToReach -= points;
                    if (pointsToReach < 0)
                    {
                        pointsToReach += points;
                        unsuccessful++;
                        continue;
                    }
                }
                if (type == "Double")
                {
                    pointsToReach -= points * 2;
                    if (pointsToReach < 0)
                    {
                        pointsToReach += points * 2;
                        unsuccessful++;
                        continue;
                    }
                }
                if (type == "Triple")
                {
                    pointsToReach -= points * 3;
                    if (pointsToReach < 0)
                    {
                        pointsToReach += points * 3;
                        unsuccessful++;
                        continue;
                    }
                }

                successful++;

                if(pointsToReach == 0)
                {
                    break;
                }
            }
            if (pointsToReach == 0) Console.WriteLine($"{name} won the leg with {successful} shots.");
            if (type == "Retire") Console.WriteLine($"{name} retired after {unsuccessful} unsuccessful shots.");
        }
    }
}
