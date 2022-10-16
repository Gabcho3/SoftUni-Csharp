using System;

namespace T01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = 0;
            int hours = 0;

            for (int i = 0; i < 3; i++)
                students += int.Parse(Console.ReadLine());

            int allStudents = int.Parse(Console.ReadLine());

            while (allStudents > 0)
            {
                hours++;
                allStudents -= students;

                if (hours % 4 == 0)
                    hours++;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
