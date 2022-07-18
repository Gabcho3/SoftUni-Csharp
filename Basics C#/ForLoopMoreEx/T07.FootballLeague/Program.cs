using System;

namespace T07.FootballLeague
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            double fans = double.Parse(Console.ReadLine());
            double inSectorA = 0;
            double inSectorB = 0;
            double inSectorV = 0;
            double inSectorG = 0;
            for(int fan = 1; fan <= fans; fan++)
            {
                string sector = Console.ReadLine();
                if(sector == "A")
                {
                    inSectorA++;
                }
                if (sector == "B")
                {
                    inSectorB++;
                }
                if (sector == "V")
                {
                    inSectorV++;
                }
                if (sector == "G")
                {
                    inSectorG++;
                }
            }
            double averageSectorA = inSectorA / fans * 100;
            double averageSectorB = inSectorB / fans * 100;
            double averageSectorV = inSectorV / fans * 100;
            double averageSectorG = inSectorG / fans * 100;
            double totalaverage = fans / capacity * 100;

            
            Console.WriteLine($"{averageSectorA:f2}%");
            Console.WriteLine($"{averageSectorB:f2}%");
            Console.WriteLine($"{averageSectorV:f2}%");
            Console.WriteLine($"{averageSectorG:f2}%");
            Console.WriteLine($"{totalaverage:f2}%");
        }
    }
}
