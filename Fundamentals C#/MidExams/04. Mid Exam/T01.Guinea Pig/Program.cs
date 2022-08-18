using System;

namespace T01.Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //* 1000 -> kg to gram
            double food = double.Parse(Console.ReadLine()) * 1000;
            double hay = double.Parse(Console.ReadLine()) * 1000;
            double cover = double.Parse(Console.ReadLine()) * 1000;
            double weight = double.Parse(Console.ReadLine()) * 1000;

            bool notEnough = false;

            for(int day = 1; day <= 30; day++)
            {
                food -= 300;

                if (day % 2 == 0)
                    hay -= food * 0.05;

                if (day % 3 == 0)
                    cover -= weight / 3;

                if (food <= 0 || hay <= 0 || cover <= 0)
                {
                    notEnough = true;
                    break;
                }
            }

            if (notEnough)
                Console.WriteLine("Merry must go to the pet store!");

            else
                Console.WriteLine($"Everything is fine! Puppy is happy!" +
                    $" Food: {food/ 1000:f2}, Hay: {hay / 1000:f2}, Cover: {cover / 1000:f2}.");
        }
    }
}
