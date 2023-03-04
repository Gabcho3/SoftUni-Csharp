using _07.Military.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military.Classes
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        public string PartName { get; }

        public int HoursWorked { get; }

        public override string ToString()
            => $"Part Name: {PartName} Hours Worked: {HoursWorked}";
    }
}
