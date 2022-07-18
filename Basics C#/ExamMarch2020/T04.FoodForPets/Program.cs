using System;

namespace T04.FoodForPets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());

            int dog = 0;
            int cat = 0;

            double foodForDay = 0;
            double dogFood = 0;
            double catFood = 0;
            double biscuits = 0;
            double totalFood = 0;

            for(int day = 1; day <= days; day++)
            {
                dog = int.Parse(Console.ReadLine());
                cat = int.Parse(Console.ReadLine());

                foodForDay = dog + cat;
                dogFood += foodForDay - cat;
                catFood += foodForDay - dog;
                
                if(day % 3 == 0)
                {
                    biscuits += foodForDay * 0.10;
                }
                totalFood = catFood + dogFood;
            }
            double percentFood = totalFood / food * 100;
            double percentDog = dogFood / totalFood * 100;
            double percentCat = catFood / totalFood * 100;
            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{percentFood:F2}% of the food has been eaten.");
            Console.WriteLine($"{percentDog:F2}% eaten from the dog.");
            Console.WriteLine($"{percentCat:F2}% eaten from the cat.");
            
           
        }
    }
}
