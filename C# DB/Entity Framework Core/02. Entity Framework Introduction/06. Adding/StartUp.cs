using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            string output = AddNewAddressToEmployee(context);
            Console.WriteLine(output);
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(address);
            context.SaveChanges();


            var employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            if (employee != null)
            {
                employee.Address = address;
            }

            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine(e);
            }

            return sb.ToString().TrimEnd();
        }
    }
}