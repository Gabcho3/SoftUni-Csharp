using System;

namespace T06.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //name actor 
            //points from Academy
            //number of jury

            //name of jury
            //points give

            //points = letters of name * givepoints / 2
            //if points > 1250.5 --> nominee

            string nameActor = Console.ReadLine();
            double pointsAcademy = double.Parse(Console.ReadLine());
            int jury = int.Parse(Console.ReadLine());
            double points = pointsAcademy;
            
            for(int i = 1; i <= jury; i++)
            {
                string nameJury = Console.ReadLine();
                int lettersOfJuryName = nameJury.Length;
                double pointsGive = double.Parse(Console.ReadLine());
                points += (lettersOfJuryName * pointsGive) / 2;

                if (points > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {points:F1}!");
                    return;
                }
            }
                    Console.WriteLine($"Sorry, {nameActor} you need {1250.5 - points:F1} more!");
        }
    }
}
