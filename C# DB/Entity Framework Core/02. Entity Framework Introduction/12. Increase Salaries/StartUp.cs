using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            string output =IncreaseSalaries(context);
;            Console.WriteLine(output);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departments = 
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };


            var employeesInDepartments = context.Employees
                .Where(e => departments.Contains(e.Department.Name))
                .ToList();

            foreach (var e in employeesInDepartments)
            {
                e.Salary *= 1.12m;
            }

            context.SaveChanges();

            employeesInDepartments = employeesInDepartments
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var e in employeesInDepartments)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}