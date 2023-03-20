using _07.Military.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military.Classes
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string firstName, string lastName, string id, decimal salary, string corps)
            : base(firstName, lastName, id, salary, corps)
        {
            Repairs = new List<Repair>();
        }

        public List<Repair> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            output.AppendLine($"Corps: {Corps}");
            output.Append("Repairs:");
            foreach (Repair repair in Repairs)
            {
                output.Append(Environment.NewLine + "  " + repair.ToString());
            }
            return output.ToString();
        }
    }
}
