using System;

namespace T06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string film = Console.ReadLine();
            int freePlace = int.Parse(Console.ReadLine());
            string type = "";

            double students = 0;
            double standards = 0;
            double kids = 0;
            double ticketsPerFilm = 0;
            double totalTickets = 0;
            double average = 0;

            while (true)
            {
                for (int place = 1; place <= freePlace; place++)
                {
                    type = Console.ReadLine();
                    if(type == "End")
                    {
                        break;
                    }
                    if (type == "student")
                    {
                        students++;
                        ticketsPerFilm++;
                    }
                    if (type == "standard")
                    {
                        standards++;
                        ticketsPerFilm++;
                    }
                    if (type == "kid")
                    {
                        kids++;
                        ticketsPerFilm++;
                    }
                    average = ticketsPerFilm / freePlace * 100;
                }
                totalTickets += ticketsPerFilm;
                ticketsPerFilm = 0;
                Console.WriteLine($"{film} - {average:f2}% full.");
                film = Console.ReadLine();
                if(film == "Finish")
                {
                    break;
                }
                freePlace = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            double averageStudents = students / totalTickets * 100;
            double averageStandards = standards / totalTickets * 100;
            double averageKids = kids / totalTickets * 100;
            Console.WriteLine($"{averageStudents:f2}% student tickets.");
            Console.WriteLine($"{averageStandards:f2}% standard tickets.");
            Console.WriteLine($"{averageKids:f2}% kids tickets.");
        }
    }
}
