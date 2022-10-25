using System;

namespace T01._Cooking_Masterclass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceFlour = double.Parse(Console.ReadLine());
            double priceEgg = double.Parse(Console.ReadLine());
            double priceApron = double.Parse(Console.ReadLine());

            double totalPrice = 0;

            for(int i = 1; i <= students; i++)
            {
                totalPrice += priceFlour + 10 * priceEgg;

                if (i % 5 == 0)
                    totalPrice -= priceFlour; //free package
            }

            totalPrice += Math.Ceiling(students * 1.20) * priceApron; //adding 20% more aprons

            if (budget >= totalPrice)
                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");

            else
                Console.WriteLine($"{totalPrice - budget:f2}$ more needed.");
        }
    }
}
