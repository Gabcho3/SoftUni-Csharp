using System;

namespace T11._Refactor_Volume_of_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Length: ");
            double length = double.Parse(Console.ReadLine()); //0 -> double.Parse(Console.ReadLine())

            Console.Write("Width: ");
            double hight = double.Parse(Console.ReadLine()); //0 -> double.Parse(Console.ReadLine())

            Console.Write("Height: "); //heigth -> height

            double volume = double.Parse(Console.ReadLine()); //0 -> double.Parse(Console.ReadLine())

            volume = (length * hight * volume) / 3; //+ -> *

            Console.WriteLine($"Pyramid Volume: {volume:f2}");

        }
    }
}
