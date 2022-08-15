using System;

namespace T04.Inches_to_Centimeters___FirstSteps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inches = double.Parse(Console.ReadLine());
            double centimetres = inches * 2.54;
            Console.WriteLine(centimetres);
        }
    }
}
