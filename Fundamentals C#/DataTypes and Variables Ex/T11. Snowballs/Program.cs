using System;
using System.Numerics;
namespace T11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int snowballs = int.Parse(Console.ReadLine());
            BigInteger highestValue = 0;
            BigInteger bestSnow = 0;
            BigInteger bestTime = 0;
            BigInteger bestQuality = 0;

            for(int snowball = 1; snowball <= snowballs; snowball++) { 
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);
                //double because we CAN'T use Math.Pow() with integer
                

                if(snowballValue > highestValue) {
                    highestValue = snowballValue;
                    bestSnow = snowballSnow;
                    bestTime = snowballTime;
                    bestQuality = snowballQuality;
                }
            }
            Console.WriteLine($"{bestSnow} : {bestTime} = {highestValue} ({bestQuality})");
        }
    }
}
