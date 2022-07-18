
using System;

namespace T03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double people = ushort.Parse(Console.ReadLine()); //double because of Math.Ceiling()
            double capacity = ushort.Parse(Console.ReadLine()); //double beacuse of Math.Ceiling()
            double courses = Math.Ceiling(people / capacity);
            Console.WriteLine(courses);
        }
    }
}
