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
            string output = GetAddressesByTown(context);
;           Console.WriteLine(output);
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
           var addresses = context.Addresses
               .AsNoTracking()
               .OrderByDescending(a => a.Employees.Count)
               .ThenBy(a => a.Town!.Name)
               .ThenBy(a => a.AddressText)
               .Select(a => new
               {
                   AddressText = a.AddressText!,
                   TownName = a.Town!.Name,
                   EmployeesCount = a.Employees.Count
               })
               .Take(10)
               .ToList();


            StringBuilder sb = new StringBuilder();
            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }
    }
}