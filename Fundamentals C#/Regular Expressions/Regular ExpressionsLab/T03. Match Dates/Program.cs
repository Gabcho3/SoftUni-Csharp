using System;
using System.Text.RegularExpressions;

namespace T03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"\b(?<day>\d{2})(?<sep>[.\-\/])(?<mon>[A-Z]{1}[a-z]{2})\k<sep>(?<y>[0-9]{4})\b";

            string dates = Console.ReadLine();

            var matches = Regex.Matches(dates, patern);

            foreach(Match date in matches)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["mon"].Value;
                var year = date.Groups["y"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
