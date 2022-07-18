using System;

namespace T05.EasterBake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cakes = int.Parse(Console.ReadLine());

            double totalSugar = 0;
            double totalFlour = 0;
            int maxSugar = int.MinValue;
            int maxFlour = int.MinValue;

            for(int cake = 1; cake <= cakes; cake++)
            {
                int sugarGrams = int.Parse(Console.ReadLine());
                if(sugarGrams > maxSugar) maxSugar = sugarGrams;

                int flourGrams = int.Parse(Console.ReadLine());
                if(flourGrams > maxFlour) maxFlour = flourGrams;

                totalSugar += sugarGrams;
                totalFlour += flourGrams;
            }
            double sugar = totalSugar / 950;
            double flour = totalFlour / 750;
            Console.WriteLine($"Sugar: {Math.Ceiling(sugar)}");
            Console.WriteLine($"Flour: {Math.Ceiling(flour)}");
            Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");
        }
    }
}
