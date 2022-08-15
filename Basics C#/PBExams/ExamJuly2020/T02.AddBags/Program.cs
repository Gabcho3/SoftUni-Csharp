using System;

namespace T02.AddBags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceOver20kg = double.Parse(Console.ReadLine());
            double kgLuggage = double.Parse(Console.ReadLine());
            int daysBefore = int.Parse(Console.ReadLine());
            int luggage = int.Parse(Console.ReadLine());
            double price = 0;

            if (kgLuggage < 10)
            {
                price = priceOver20kg * 0.20;
            }
            if (kgLuggage >= 10 && kgLuggage <= 20)
            {
                price = priceOver20kg * 0.50;
            }
            if(kgLuggage > 20)
            {
                price = priceOver20kg;
            }

            if (daysBefore > 30) price = (price + (price * 0.10))  * luggage;
            if (daysBefore >= 7 && daysBefore <= 30) price = (price +(price * 0.15)) * luggage;
            if (daysBefore < 7) price = (price + (price * 0.40)) * luggage;
            Console.WriteLine($"The total price of bags is: {price:f2} lv.");
        }
    }
}
