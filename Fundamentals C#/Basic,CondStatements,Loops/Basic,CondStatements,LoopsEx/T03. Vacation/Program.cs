using System;

namespace T03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            var type = Console.ReadLine();
            var day = Console.ReadLine();
            var total = 0.0;
            switch(type)
            {
                case "Students":
                    switch(day)
                    {
                        case "Friday":
                            total = people * 8.45;
                            break;
                        case "Saturday":
                            total = people * 9.80;
                            break;
                        case "Sunday":
                            total = people * 10.46;
                            break;
                    }
                    if (people >= 30) total -= total * 0.15;
                    break;
                case "Business":
                    switch (day)
                    {
                        case "Friday":
                            total = people * 10.90;
                            if (people >= 100) total -= 10 * 10.90;
                            break;
                        case "Saturday":
                            total = people * 15.60;
                            if (people >= 100) total -= 10 * 15.60;
                            break;
                        case "Sunday":
                            total = people * 16;
                            if (people >= 100) total -= 10 * 16;
                            break;
                    }
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday":
                            total = people * 15;
                            break;
                        case "Saturday":
                            total = people * 20;
                            break;
                        case "Sunday":
                            total = people * 22.50;
                            break;
                    }
                    if (people >= 10 && people <= 20) total -= total * 0.05;
                    break;
            }
            Console.WriteLine($"Total price: {total:f2}");
        }
    }
}
