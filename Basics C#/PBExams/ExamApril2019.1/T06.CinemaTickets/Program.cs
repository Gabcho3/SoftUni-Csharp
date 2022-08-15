using System;

namespace T06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double students = 0;
            double standards = 0;
            double kids = 0;
            double total = 0;
            while(name != "Finish")
            {
                string currentFilm = "";
                double totalForFilm = 0;
                double places = int.Parse(Console.ReadLine());
                for(int place = 1; place <= places; place++)
                {
                    string type = Console.ReadLine();
                    currentFilm = name;
                    if(type == "End")
                    {
                        break;
                    }
                    switch(type)
                    {
                        case "student": students++; totalForFilm++;  break;
                        case "standard": standards++; totalForFilm++; break;
                        case "kid": kids++; totalForFilm++; break;
                    }
                }
                total += totalForFilm;
                double averageForFilm = totalForFilm / places * 100;
                Console.WriteLine($"{currentFilm} - {averageForFilm:f2}% full.");
                totalForFilm = 0;
                name = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {total}");
            double averageStudents = students / total * 100;
            Console.WriteLine($"{averageStudents:f2}% student tickets.");
            double averageStandards = standards / total * 100;
            Console.WriteLine($"{averageStandards:f2}% standard tickets.");
            double averageKids = kids / total * 100;
            Console.WriteLine($"{averageKids:f2}% kids tickets.");
        }
    }
}
