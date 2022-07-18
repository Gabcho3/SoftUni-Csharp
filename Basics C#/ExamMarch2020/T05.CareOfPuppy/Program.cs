using System;

namespace T05.CareOfPuppy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kgFood = int.Parse(Console.ReadLine()) * 1000; //kg in gram
            string input = Console.ReadLine();
            int totalAte = 0;

            while(input != "Adopted")
            {
                int foodAteGrams = int.Parse(input);
                totalAte += foodAteGrams;
                input = Console.ReadLine();
            }
            if(totalAte <= kgFood)
            {
                Console.WriteLine($"Food is enough! Leftovers: {kgFood - totalAte} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {totalAte - kgFood} grams more."); 
            }
        }
    }
}
