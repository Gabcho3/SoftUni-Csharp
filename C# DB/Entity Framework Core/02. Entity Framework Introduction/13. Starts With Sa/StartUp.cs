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
            string output = GetEmployeesByFirstNameStartingWithSa(context);
;           Console.WriteLine(output);
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            string stringStartWith = "Sa";
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith(stringStartWith))
                .Select(e => new
                {
                    FirstName = e.FirstName!,
                    LastName = e.LastName!,
                    JobTitle = e.JobTitle!,
                    Salary = e.Salary!
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}