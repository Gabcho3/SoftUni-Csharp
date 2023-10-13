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
            string output = RemoveTown(context);
;           Console.WriteLine(output);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            string townName = "Seattle";

            var employeesWhoLivesInTown = context.Employees
                .Where(e => e.Address!.Town!.Name == townName)
                .ToList();

            foreach (var e in employeesWhoLivesInTown)
            {
                e.AddressId = null;
            }
            context.SaveChanges();

            var addressesWithTown = context.Addresses
                .Where(a => a.Town!.Name == townName)
                .ToList();
            context.Addresses.RemoveRange(addressesWithTown);

            Town townToDelete = context.Towns.FirstOrDefault(t => t.Name == townName)!;
            context.Towns.Remove(townToDelete);
            context.SaveChanges();

            return $"{addressesWithTown.Count} addresses in Seattle were deleted";
        }
    }
}