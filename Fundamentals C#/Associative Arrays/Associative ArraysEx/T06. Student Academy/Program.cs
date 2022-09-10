using System;
using System.Collections.Generic;
using System.Linq;

namespace T06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var studentsAndGrades = new Dictionary<string, List<double>>();

            for(int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if(studentsAndGrades.ContainsKey(student))
                    studentsAndGrades[student].Add(grade);

                else
                {
                    studentsAndGrades.Add(student, new List<double>());
                    studentsAndGrades[student].Add(grade);
                }
            }

            var goodStudentsAndGrades = studentsAndGrades.Where(g => g.Value.Average() >= 4.50);

            foreach (var student in goodStudentsAndGrades)
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
        }
    }
}
