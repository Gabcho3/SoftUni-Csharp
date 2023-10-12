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
            string output = GetEmployee147(context);
;            Console.WriteLine(output);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employees = context.Employees
                .AsNoTracking()
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FirstName = e.FirstName!,
                    LastName = e.LastName!,
                    JobTitle = e.JobTitle!,
                    ProjectsNames = e.Projects
                        .OrderBy(p => p.Name)
                        .Select(p => p.Name)
                });


            StringBuilder sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                foreach (var projectName in e.ProjectsNames)
                {
                    sb.AppendLine(projectName);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}