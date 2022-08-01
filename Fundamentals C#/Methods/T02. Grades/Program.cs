using System;

namespace T02._Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double garde = double.Parse(Console.ReadLine());
            CheckGrades(garde);
        }

        static void CheckGrades(double grade)
        {
            if (grade < 3.00)
                Console.WriteLine("Fail");

            else if (grade < 3.50)
                Console.WriteLine("Poor");

            else if (grade < 4.50)
                Console.WriteLine("Good");

            else if (grade < 5.50)
                Console.WriteLine("Very good");

            else
                Console.WriteLine("Excellent");

        }
    }
}
