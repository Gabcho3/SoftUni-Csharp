using System;

namespace T02.FamilyTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double priceForNight = double.Parse(Console.ReadLine());
            int percentForCosts = int.Parse(Console.ReadLine());

            if (nights > 7) priceForNight -= priceForNight * 0.05;
            double priceForNights = priceForNight * nights;
            double costs = bujet * percentForCosts / 100;
            double total = priceForNights + costs;

            if (bujet >= total) Console.WriteLine($"Ivanovi will be left with {bujet - total:f2} leva after vacation.");
            else Console.WriteLine($"{total - bujet:f2} leva needed.");
        }
    }
}
