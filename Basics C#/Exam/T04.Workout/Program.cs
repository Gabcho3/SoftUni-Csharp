using System;

namespace T04.Workout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double kilometers = double.Parse(Console.ReadLine());
            double totalKilometers = kilometers;
            bool kilometersReach = false;

            for(int day = 1; day <= days; day++)
            {
                double percent = double.Parse(Console.ReadLine()) / 100;
                kilometers += kilometers * percent;
                totalKilometers += kilometers;
                if(totalKilometers >= 1000)
                {
                    kilometersReach = true;
                }
            }
            if(kilometersReach)
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(totalKilometers - 1000)} more kilometers!");
            }
            else
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000 - totalKilometers)} more kilometers");
            }
        }
    }
}
