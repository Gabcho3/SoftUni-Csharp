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
            string output = GetDepartmentsWithMoreThan5Employees(context);
;            Console.WriteLine(output);
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .AsNoTracking()
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerName = d.Manager.FirstName + " " + d.Manager.LastName,
                    EmployeeInfo = d.Employees.Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        JobTitle = e.JobTitle
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()

                })
                .ToList();


            StringBuilder sb = new StringBuilder();
            foreach (var d in departments)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerName}");
                foreach (var e in d.EmployeeInfo)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}