using System;

namespace T02.SleepyTomCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int holidays = int.Parse(Console.ReadLine());
            int workdays = 365 - holidays;

            int onHolidays = holidays * 127; //minutes
            int onWorkdays = workdays * 63; //minutes
            int totalMinutes = onHolidays + onWorkdays;

            int restMinutes = 30000 - totalMinutes;
            int M = restMinutes % 60;
            int H = restMinutes / 60;
            if (totalMinutes <= 30000)
            {
                Console.WriteLine($"Tom sleeps well");
                Console.WriteLine($"{H} hours and {M} minutes less for play");
            }
            else
            {
                restMinutes = totalMinutes - 30000;
                Console.WriteLine($"Tom will run away");
                Console.WriteLine($"{-H} hours and {-M} minutes more for play");
            }
        }
    }
}
