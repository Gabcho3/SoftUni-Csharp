using System;

namespace T04.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double studentsOnExam = double.Parse(Console.ReadLine());
            double failedStudents = 0;
            double between3And4 = 0;
            double between4And5 = 0;
            double topStudents = 0;
            double total = 0.00;

            for(double student = 1; student <= studentsOnExam; student++)
            {
                double grade = double.Parse(Console.ReadLine());
                if(grade >= 2.00 && grade < 3.00)
                {
                    failedStudents++;
                    total += grade;
                }
                if(grade >= 3.00 && grade < 4.00)
                {
                    between3And4++;
                    total += grade;
                }
                if(grade >= 4.00 && grade < 5.00)
                {
                    between4And5++;
                    total += grade;
                }
                if(grade >= 5.00)
                {
                    topStudents++;
                    total += grade;
                }
            }
            double averageFailed = failedStudents / studentsOnExam * 100;
            double averageBetween3And4 = between3And4 / studentsOnExam * 100;
            double averageBetween4And5 = between4And5 / studentsOnExam * 100;
            double averageTopStudents = topStudents / studentsOnExam * 100;

            Console.WriteLine($"Top students: {averageTopStudents:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {averageBetween4And5:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {averageBetween3And4:F2}%");
            Console.WriteLine($"Fail: {averageFailed:F2}%");
            Console.WriteLine($"Average: {total / studentsOnExam:F2}");
        }
    }
}
