using System;

namespace T10.WeatherForecastPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tp = double.Parse(Console.ReadLine());

            if (tp >= 26 & tp <= 35)
            {
                Console.WriteLine("Hot");
            }
            else if (tp >= 20.1 & tp <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (tp >= 15 & tp <= 20)
            {
                Console.WriteLine("Mild");
            }
            else if (tp >= 12 & tp < 15)
            {
                Console.WriteLine("Cool");
            }
            else if (tp >= 5 & tp < 12)
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
