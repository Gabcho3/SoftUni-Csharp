using System;

namespace T03._Mil_Km
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double miles = double.Parse(Console.ReadLine());
            double km = miles * 1.60934;
            Console.WriteLine($"{km:f2}");
        }
    }
}
