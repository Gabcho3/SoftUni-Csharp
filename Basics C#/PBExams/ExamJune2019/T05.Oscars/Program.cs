using System;

namespace T05.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfActor = Console.ReadLine();
            double pointsFromAcademy = double.Parse(Console.ReadLine());
            int juries = int.Parse(Console.ReadLine());
            double totalPoints = 0;
            bool nominee = false;
            for(int jury = 1; jury <= juries; jury++)
            {
                string nameOfJury = Console.ReadLine();
                double pointsFromJury = double.Parse(Console.ReadLine());
                int length = nameOfJury.Length;
                totalPoints += (length * pointsFromJury) / 2;
                if(totalPoints + pointsFromAcademy > 1250.5)
                {
                    nominee = true;
                    break;
                }
            }
            if (nominee) Console.WriteLine($"Congratulations, {nameOfActor} got a nominee for leading role with {totalPoints + pointsFromAcademy:f1}!");
            else Console.WriteLine($"Sorry, {nameOfActor} you need {1250.5 - totalPoints - pointsFromAcademy:f1} more!");
        }
    }
}
