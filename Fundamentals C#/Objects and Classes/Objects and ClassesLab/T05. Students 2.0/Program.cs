using System;
using System.Collections.Generic;

namespace T05._Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();

            List<Student> students = new List<Student>();

            while (data[0] != "end")
            {
                Student student = new Student(data[0], data[1], int.Parse(data[2]), data[3]);

                for(int i = 0; i < students.Count; i++)
                    if (students[i].FirstName == data[0] && students[i].LastName == data[1])
                        students.RemoveAt(i);

                students.Add(student);

                data = Console.ReadLine().Split();
            }

            string city = Console.ReadLine();

            foreach (Student student in students)
                if (student.HomeTown == city)
                    Console.WriteLine("{0} {1} is {2} years old.", student.FirstName, student.LastName, student.Age);
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, int age, string town)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = town;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }
    }
}
