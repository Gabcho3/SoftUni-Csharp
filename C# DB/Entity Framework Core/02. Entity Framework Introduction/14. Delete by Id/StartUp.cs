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
            string output = DeleteProjectById(context);
;           Console.WriteLine(output);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeesProjectsToRemove = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(employeesProjectsToRemove);

            var projectToRemove = context.Projects.Find(2);
            context.Projects.RemoveRange(projectToRemove!);

            var projectsNames = context.Projects.Select(p => p.Name).Take(10).ToArray();

            return string.Join(Environment.NewLine, projectsNames);
        }
    }
}