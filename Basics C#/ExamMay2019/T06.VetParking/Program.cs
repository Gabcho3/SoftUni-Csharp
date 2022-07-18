using System;

namespace T06.VetParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double sumForDay = 0;
            double price = 0;

            for(int day = 1; day <= days; day++)
            {
                for(int hour = 1; hour <= hours; hour++)
                {
                    if (day % 2 == 0 && hour % 2 != 0) { price += 2.50; sumForDay += 2.50; }
                    else if (day % 2 != 0 && hour % 2 == 0) { price += 1.25; sumForDay += 1.25; }
                    else { price += 1.00; sumForDay += 1; }
                }
                Console.WriteLine($"Day: {day} - {sumForDay:f2} leva");
                sumForDay = 0;
            }
            Console.WriteLine($"Total: {price:f2} leva");
        }
    }
}
