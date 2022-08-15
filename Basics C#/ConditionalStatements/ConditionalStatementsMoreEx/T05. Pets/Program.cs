using System;

namespace T05._Pets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int restFood = int.Parse(Console.ReadLine());
            double kgDog = double.Parse(Console.ReadLine());
            double kgCat = double.Parse(Console.ReadLine());
            double grTurtle = double.Parse(Console.ReadLine());

            double foodForDog = days * kgDog;
            double foodForCat = days * kgCat;
            double foodForTurtle = days * grTurtle / 1000;
            double totalFood = foodForDog + foodForCat + foodForTurtle;

            if (totalFood <= restFood)
            {
                double rest = restFood - totalFood;
                Console.WriteLine($"{Math.Floor(rest)} kilos of food left.");
            }
            else
            {
                double rest = totalFood - restFood;
                Console.WriteLine($"{Math.Ceiling(rest)} more kilos of food are needed.");
            }
        }
    }
}
