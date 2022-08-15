using System;

namespace T01._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double foodGrams = double.Parse(Console.ReadLine()) * 1000;
            double hayGrams = double.Parse(Console.ReadLine()) * 1000;
            double coverGrams = double.Parse(Console.ReadLine()) * 1000;
            double weightGrams = double.Parse(Console.ReadLine()) * 1000;

            bool notEnough = false;

            for(int day = 1; day <= 30; day++)
            {
                foodGrams -= 300;

                if(day % 2 == 0)
                {
                    hayGrams -= foodGrams * 0.05;
                }

                if(day % 3 == 0)
                {
                    coverGrams -= weightGrams * 1.0 / 3.0;
                }

                if (foodGrams == 0)
                    notEnough = true;

                if (hayGrams == 0)
                    notEnough = true;

                if (coverGrams == 0)
                    notEnough = true;

                if (notEnough)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }

            Console.WriteLine($"Everything is fine! Puppy is happy! " +
                $"Food: {foodGrams / 1000:f2}, " +
                $"Hay: {hayGrams / 1000:f2}, " +
                $"Cover: {coverGrams / 1000:f2}");
        }
    }
}
