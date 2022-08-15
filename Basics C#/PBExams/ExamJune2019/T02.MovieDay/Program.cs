using System;

namespace T02.MovieDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int timeForPhotos = int.Parse(Console.ReadLine());
            int scenes = int.Parse(Console.ReadLine());
            int timeForScene = int.Parse(Console.ReadLine());

            double preparation = timeForPhotos * 0.15;
            int timeForScenes = scenes * timeForScene;
            double neededTime = preparation + timeForScenes;

            if(timeForPhotos >= neededTime) Console.WriteLine($"You managed to finish the movie on time! You have {(timeForPhotos - neededTime)} minutes left!");
            else Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(neededTime - timeForPhotos)} minutes.");
        }
    }
}


