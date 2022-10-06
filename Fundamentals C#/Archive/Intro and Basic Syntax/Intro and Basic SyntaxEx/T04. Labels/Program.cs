using System;

namespace T04._Labels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            int sugar = int.Parse(Console.ReadLine());

            double kcal = (energy / 100.0) * volume;
            double gramsSugar = (sugar / 100.0) * volume;

            Console.WriteLine($"{volume}ml {name}:\n{kcal:f2}kcal, {gramsSugar:f2}g sugars");
        }
    }
}
