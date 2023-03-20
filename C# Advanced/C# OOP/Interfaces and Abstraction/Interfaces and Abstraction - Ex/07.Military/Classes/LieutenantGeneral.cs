using _07.Military.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military.Classes
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string firstName, string lastName, string id, decimal salary) 
            : base(firstName, lastName, id, salary)
        {
            Privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            output.Append("Privates:");

            foreach (var pr in Privates)
                output.Append(Environment.NewLine + "  " + pr.ToString());

            return output.ToString();
        }
    }
}
