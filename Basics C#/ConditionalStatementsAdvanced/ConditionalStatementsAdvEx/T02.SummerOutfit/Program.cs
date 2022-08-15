using System;

namespace T02.SummerOutfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double gr = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            if (gr >= 10 && gr <= 18)
            {
                if (day == "Morning")
                {
                    Console.WriteLine($"It's {gr} degrees, get your Sweatshirt and Sneakers.");
                }
                if (day == "Afternoon")
                {
                    Console.WriteLine($"It's {gr} degrees, get your Shirt and Moccasins.");
                }
                if (day == "Evening")
                {
                    Console.WriteLine($"It's {gr} degrees, get your Shirt and Moccasins.");
                }
            }

            if (gr > 18 && gr <= 24)
            {
                if (day == "Morning")
                {
                    Console.WriteLine($"It's {gr} degrees, get your Shirt and Moccasins.");
                }
                if (day == "Afternoon")
                {
                    Console.WriteLine($"It's {gr} degrees, get your T-Shirt and Sandals.");
                }
                if (day == "Evening")
                {
                    Console.WriteLine($"It's {gr} degrees, get your Shirt and Moccasins.");
                }
            }

            if (gr >= 25)
            {
                if (day == "Morning")
                {
                    Console.WriteLine($"It's {gr} degrees, get your T-Shirt and Sandals.");
                }
                if (day == "Afternoon")
                {
                    Console.WriteLine($"It's {gr} degrees, get your Swim Suit and Barefoot.");
                }
                if (day == "Evening")
                {
                    Console.WriteLine($"It's {gr} degrees, get your Shirt and Moccasins.");
                }
            }
        }
    }
}
