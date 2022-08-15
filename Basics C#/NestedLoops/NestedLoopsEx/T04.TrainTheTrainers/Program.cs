using System;

namespace T04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int juries = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            double grade = 0;
            double averageCounter = 0;
            double grades = 0;
            
            while(name != "Finish")
            {
                double average = 0;
                double totalForProject = 0;
                for(int jury = 1; jury <= juries; jury++)
                {
                    grade = double.Parse(Console.ReadLine());
                    totalForProject += grade;
                    grades += grade;
                    averageCounter++;
                    average = totalForProject / jury;
                }
                totalForProject = 0;
                Console.WriteLine($"{name} - {average:f2}.");
                name = Console.ReadLine();
            }
            double totalAverage = grades / averageCounter;
            Console.WriteLine($"Student's final assessment is {totalAverage:f2}.");
        }
    }
}
