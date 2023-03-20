using _07.Military.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace _07.Military.Classes
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string firstName, string lastName, string id, decimal salary, string corps)
            : base(firstName, lastName, id, salary, corps)
        {
            Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            output.AppendLine($"Corps: {Corps}");
            output.Append("Missions:");

            foreach(var mission in Missions)
            {
                output.Append(Environment.NewLine + "  " + mission.ToString());
            }
            return output.ToString();
        }
    }
}
