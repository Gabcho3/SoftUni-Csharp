using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace T01._Company_Roster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();
            List<string> departments = new List<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] data = Console.ReadLine().Split();

                Employee employee = new Employee
                {
                    Name = data[0],
                    Salary = double.Parse(data[1]),
                    Department = data[2]
                };

                employees.Add(employee);
                departments.Add(employee.Department);
            }

            string bestDepartment = string.Empty;
            double maxSalary = 0;

            //Finding Best Department
            for (int i = 0; i < employees.Count; i++)
            {
                double salary = 0;
                int coincidences = 0;

                for(int j = 0; j < departments.Count; j++)
                {
                    if (employees[i].Department == departments[j])
                    {
                        salary += employees[j].Salary;
                        coincidences++;
                    }
                }

                salary /= coincidences;

                if(salary > maxSalary)
                {
                    maxSalary = salary;
                    bestDepartment = employees[i].Department;
                }
            }

            //Printing Output
            Console.WriteLine($"Highest Average Salary: {bestDepartment}");

            employees = employees.OrderByDescending(s => s.Salary).ToList();

            foreach (var employee in employees)
                if (employee.Department == bestDepartment)
                    Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
        }
    }

    class Employee
    {
        public string Name { get; set; }

        public double Salary { get; set; }

        public string Department { get; set; }
    }
}
