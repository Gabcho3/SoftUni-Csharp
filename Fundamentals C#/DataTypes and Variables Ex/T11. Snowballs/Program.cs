using System;

namespace T11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int snowballs = int.Parse(Console.ReadLine());
            double highestValue = int.MinValue;

            int bestSnowballSnow = 0;
            int bestSnowballTime = 0;
            int bestSnowballQuality = 0;
            for(int snowball = 1; snowball <= snowballs; snowball++) { 
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                double snowballValue = Math.Pow(snowballSnow / snowballTime, snowballQuality);
                //double because we CAN'T use Math.Pow() with integer
                

                if(snowballValue >= highestValue) {
                    highestValue = snowballValue;
                    bestSnowballSnow = snowballSnow;
                    bestSnowballTime = snowballTime;
                    bestSnowballQuality = snowballQuality;
                }
            }
            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {highestValue} ({bestSnowballQuality})");
        }
    }
}
