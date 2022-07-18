using System;

namespace Т07.SchoolCamp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string group = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            string sport;

            switch(season)
            {
                case "Winter":
                    if(group == "boys")
                    {
                        double price = 9.60 * students * nights;
                        sport = "Judo";
                        if(students >= 50)
                        {
                            price = price - (price * 0.50);
                        }
                        if(students >= 20 & students < 50)
                        {
                            price = price - (price * 0.15);
                        }
                        if(students >= 10 & students < 20)
                        {
                            price = price - (price * 0.05);
                        }
                        Console.WriteLine($"{sport} {price:F2} lv.");
                    }

                    if (group == "girls")
                    {
                        double price = 9.60 * students * nights;
                        sport = "Gymnastics";
                        if (students >= 50)
                        {
                            price = price - (price * 0.50);
                        }
                        if (students >= 20 & students < 50)
                        {
                            price = price - (price * 0.15);
                        }
                        if (students >= 10 & students < 20)
                        {
                            price = price - (price * 0.05);
                        }
                        Console.WriteLine($"{sport} {price:F2} lv.");
                    }

                    if (group == "mixed")
                    {
                        double price = 10.00 * students * nights;
                        sport = "Ski";
                        if (students >= 50)
                        {
                            price = price - (price * 0.50);
                        }
                        if (students >= 20 & students < 50)
                        {
                            price = price - (price * 0.15);
                        }
                        if (students >= 10 & students < 20)
                        {
                            price = price - (price * 0.05);
                        }
                        Console.WriteLine($"{sport} {price:F2} lv.");
                    }
                    break;

                case "Spring":
                    if (group == "boys")
                    {
                        double price = 7.20 * students * nights;
                        sport = "Tennis";
                        if (students >= 50)
                        {
                            price = price - (price * 0.50);
                        }
                        if (students >= 20 & students < 50)
                        {
                            price = price - (price * 0.15);
                        }
                        if (students >= 10 & students < 20)
                        {
                            price = price - (price * 0.05);
                        }
                        Console.WriteLine($"{sport} {price:F2} lv.");
                    }

                    if (group == "girls")
                    {
                        double price = 7.20 * students * nights;
                        sport = "Athletics";
                        if (students >= 50)
                        {
                            price = price - (price * 0.50);
                        }
                        if (students >= 20 & students < 50)
                        {
                            price = price - (price * 0.15);
                        }
                        if (students >= 10 & students < 20)
                        {
                            price = price - (price * 0.05);
                        }
                        Console.WriteLine($"{sport} {price:F2} lv.");
                    }

                    if (group == "mixed")
                    {
                        double price = 9.50 * students * nights;
                        sport = "Cycling";
                        if (students >= 50)
                        {
                            price = price - (price * 0.50);
                        }
                        if (students >= 20 & students < 50)
                        {
                            price = price - (price * 0.15);
                        }
                        if (students >= 10 & students < 20)
                        {
                            price = price - (price * 0.05);
                        }
                        Console.WriteLine($"{sport} {price:F2} lv.");
                    }
                    break;

                case "Summer":
                    if (group == "boys")
                    {
                        double price = 15.00 * students * nights;
                        sport = "Football";
                        if (students >= 50)
                        {
                            price = price - (price * 0.50);
                        }
                        if (students >= 20 & students < 50)
                        {
                            price = price - (price * 0.15);
                        }
                        if (students >= 10 & students < 20)
                        {
                            price = price - (price * 0.05);
                        }
                        Console.WriteLine($"{sport} {price:F2} lv.");
                    }

                    if (group == "girls")
                    {
                        double price = 15.00 * students * nights;
                        sport = "Volleyball";
                        if (students >= 50)
                        {
                            price = price - (price * 0.50);
                        }
                        if (students >= 20 & students < 50)
                        {
                            price = price - (price * 0.15);
                        }
                        if (students >= 10 & students < 20)
                        {
                            price = price - (price * 0.05);
                        }
                        Console.WriteLine($"{sport} {price:F2} lv.");
                    }

                    if (group == "mixed")
                    {
                        double price = 20.00 * students * nights;
                        sport = "Swimming";
                        if (students >= 50)
                        {
                            price = price - (price * 0.50);
                        }
                        if (students >= 20 & students < 50)
                        {
                            price = price - (price * 0.15);
                        }
                        if (students >= 10 & students < 20)
                        {
                            price = price - (price * 0.05);
                        }
                        Console.WriteLine($"{sport} {price:F2} lv.");
                    }
                    break;
            }
        }
    }
}
