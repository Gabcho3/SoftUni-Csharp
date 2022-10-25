using System;

namespace T01._Cat_Diet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double percentFats = double.Parse(Console.ReadLine()) / 100;
            double percentProteins = double.Parse(Console.ReadLine()) / 100;
            double percentCarbohydrates = double.Parse(Console.ReadLine()) / 100;
            double calories = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine()) / 100;

            double gramsFats = calories * percentFats / 9;
            double gramsProteins = calories * percentProteins / 4;
            double gramsCarbohydrates = calories * percentCarbohydrates / 4;
            double totalGrams = gramsFats + gramsProteins + gramsCarbohydrates;
            double caloriesForOneGram = calories / totalGrams;
            double totalCalories = (1 - water) * caloriesForOneGram;
            Console.WriteLine($"{totalCalories:f4}");
        }
    }
}
