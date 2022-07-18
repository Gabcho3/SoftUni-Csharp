using System;

namespace T01.SeriesCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int seasons = int.Parse(Console.ReadLine());
            int episodes = int.Parse(Console.ReadLine());
            double timeWithoutAd = double.Parse(Console.ReadLine());

            double adTime = timeWithoutAd * 0.20;
            double timeEpisode = timeWithoutAd + adTime;
            double extraTime = seasons * 10;
            double totalTime = timeEpisode * episodes * seasons + extraTime;
            Console.WriteLine($"Total time needed to watch the {name} series is {Math.Ceiling(totalTime)} minutes.");
        }
    }
}


