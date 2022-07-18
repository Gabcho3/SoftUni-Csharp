using System;

namespace T02.MountainRun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double metres = double.Parse(Console.ReadLine());
            double secondsForOneMeter = double.Parse(Console.ReadLine());

            double seconds = metres * secondsForOneMeter;
            double every50Metres = Math.Floor((metres / 50)) * 30;
            double totalTime = every50Metres + seconds;

            if(totalTime < recordInSeconds)
            {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {totalTime - recordInSeconds:f2} seconds slower.");
            }
        }
    }
}
