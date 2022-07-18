using System;

namespace T01._Cat_Diet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double p1 = double.Parse(Console.ReadLine()) / 100;
            double p2 = double.Parse(Console.ReadLine()) / 100;
            double p3 = double.Parse(Console.ReadLine()) / 100;
            double calories = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine()) / 100;

            double grams1 = calories * p1 / 9;
            double grams2 = calories * p2 / 4;
            double grams3 = calories * p3 / 4;
            double total1 = grams1 + grams2 + grams3;
            double for1Meal = calories / total1;
            double totalCalories = (1 - water) * for1Meal;
            Console.WriteLine($"{totalCalories:f4}");
        }
    }
}
