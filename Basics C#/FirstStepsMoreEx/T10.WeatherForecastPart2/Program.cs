using System;

namespace T10.WeatherForecastPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double temperature = double.Parse(Console.ReadLine());

            if (temperature >= 26 & temperature <= 35)
            {
                Console.WriteLine("Hot");
            }
            else if (temperature >= 20.1 & temperature <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (temperature >= 15 & temperature <= 20)
            {
                Console.WriteLine("Mild");
            }
            else if (temperature >= 12 & temperature < 15)
            {
                Console.WriteLine("Cool");
            }
            else if (temperature >= 5 & temperature < 12)
            {
                Console.WriteLine("Cold");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
