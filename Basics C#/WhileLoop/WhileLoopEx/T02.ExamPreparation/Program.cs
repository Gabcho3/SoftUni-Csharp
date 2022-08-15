using System;

namespace T02.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int problemGradesLimit = int.Parse(Console.ReadLine());
            string task = Console.ReadLine();
            int problemGrade = 0;
            double total = 0;
            int counter = 0;
            string lastTask = "";

            while (task != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                counter++;
                total += grade;
                if (grade <= 4)
                {
                    problemGrade++;
                    if (problemGrade >= problemGradesLimit)
                    {
                        break;
                    }
                }
                lastTask = task;
                task = Console.ReadLine();
            }
            double average = total / counter;
            if (problemGrade >= problemGradesLimit)
            {
                Console.WriteLine($"You need a break, {problemGrade} poor grades.");
                return;
            }
            Console.WriteLine($"Average score: {average:f2}");
            Console.WriteLine($"Number of problems: {counter}");
            Console.WriteLine($"Last problem: {lastTask}");
        }
    }
}
