using System;
using System.Collections.Generic;
using System.Xml;

namespace T05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" : ");

            var coursesAndStudents = new Dictionary<string, List<string>>();

            while (input[0] != "end")
            {
                string courseName = input[0];
                string studentName = input[1];

                if (coursesAndStudents.ContainsKey(courseName))
                    coursesAndStudents[courseName].Add(studentName);

                else
                { 
                    coursesAndStudents.Add(courseName, new List<string>());
                    coursesAndStudents[courseName].Add(studentName);
                }

                input = Console.ReadLine().Split(" : ");
            }

            foreach(var course in coursesAndStudents)
            {
                Console.WriteLine(course.Key + ": " + course.Value.Count);

                for (int i = 0; i < course.Value.Count; i++)
                    Console.WriteLine($"-- {course.Value[i]}");
            }
        }
    }
}
