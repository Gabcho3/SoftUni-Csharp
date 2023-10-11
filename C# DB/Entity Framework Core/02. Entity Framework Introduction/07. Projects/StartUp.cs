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
            string output = GetEmployeesInPeriod(context);
;            Console.WriteLine(output);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
           var employees = context.Employees
               .AsNoTracking()
               .Take(10)
               .Select(e => new
               {
                   FirstName = e.FirstName!,
                   LastName = e.LastName!,
                   ManagerFirstName = e.Manager!.FirstName,
                   ManagerLastName = e.Manager.LastName,
                   Projects = e.Projects
                       .Where(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003)
                       .Select(p => new
                       {
                           ProjectName = p.Name,
                           StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                           EndDate = p.EndDate != null ? p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                       })
               })
               .ToList();


            StringBuilder sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                if (!e.Projects.Any()) continue;
                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"-- {p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}