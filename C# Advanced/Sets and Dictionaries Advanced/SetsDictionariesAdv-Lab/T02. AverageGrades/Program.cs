using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._AverageGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            var studentsGrades = new Dictionary<string, List<decimal>>(); //name, grades

            for(int i = 0; i < students; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                decimal grade = decimal.Parse(data[1]);

                if(studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name].Add(grade);
                }

                else
                {
                    studentsGrades.Add(name, new List<decimal>());
                    studentsGrades[name].Add(grade);
                }
            }

            foreach(var student in studentsGrades.Keys)
            {
                Console.Write($"{student} -> ");
                foreach(var grade in studentsGrades[student])
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {studentsGrades[student].Average():f2})");
            }
        }
    }
}
