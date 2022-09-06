using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                Student student = new Student(data[0], data[1], double.Parse(data[2]));

                students.Add(student);
            }

            students = students.OrderByDescending(g => g.Grade).ToList();

            foreach (var student in students)
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }
    }
}
