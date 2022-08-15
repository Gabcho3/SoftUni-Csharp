using System;

namespace Т01._Day_of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dayOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int day = int.Parse(Console.ReadLine()) - 1; //day - 1 -> ZERO is first index 

            if (day >= 0 && day < dayOfWeek.Length) //length = 7, MaxIndex = 6
                Console.WriteLine(dayOfWeek[day]);
            else
                Console.WriteLine("Invalid day!");
        }
    }
}
