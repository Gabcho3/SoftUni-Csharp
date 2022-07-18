using System;
using System.Globalization;

class HolidaysBetweenTwoDates
{
    static void Main()
    {
        //debugging
        var startDate = DateTime.ParseExact(Console.ReadLine(),
            "d.M.yyyy", CultureInfo.InvariantCulture); //m -> MM (1) ; dd -> d
        var endDate = DateTime.ParseExact(Console.ReadLine(),
            "d.M.yyyy", CultureInfo.InvariantCulture); //m -> MM (2) ; dd -> d
        var holidaysCount = 0;
        for (var date = startDate; date <= endDate;)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday) holidaysCount++; //&& -> || (3)
            date = date.AddDays(1); //(4)
        }
        Console.WriteLine(holidaysCount);
    }
}