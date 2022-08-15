using System;

namespace T03.CelsiusToFahrenheit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = (celsius * (9.0 / 5.0)) + 32.00;
            Console.WriteLine($"{fahrenheit:F2}");
        }
    }
}
