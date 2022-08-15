using System;

namespace T01._Convert_Meters_To_Kilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine()); //DOUBLE because kilometers are DOUBLE
            double kilometers = meters / 1000;
            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
