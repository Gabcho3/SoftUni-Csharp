using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int CalculateDifference(string[] firstDate, string[] secondDate)
        {
            int year1 = int.Parse(firstDate[0]);
            int year2 = int.Parse(secondDate[0]);

            int month1 = int.Parse(firstDate[1]);
            int month2 = int.Parse(secondDate[1]);

            int day1 = int.Parse(firstDate[2]);
            int day2 = int.Parse(secondDate[2]);

            DateTime first = new DateTime(year1, month1, day1);
            DateTime second = new DateTime(year2, month2, day2);
            TimeSpan diff = second.Subtract(first);

            return Math.Abs(diff.Days);
        }
    }
}
