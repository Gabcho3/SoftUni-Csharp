using System;

namespace T03.Flowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemum = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string holidays = Console.ReadLine();
            double total = 0.00;

            switch (season)
            {
                case "Spring":
                    total = chrysanthemum * 2.00 + (roses * 4.10) + (tulips * 2.50);

                    if (holidays == "N")
                    {
                        if (tulips > 7)
                        {
                            total = total - (total * 0.05);
                        }
                    }
                    if (holidays == "Y")
                    {
                        total = total + (total * 0.15);
                        if (tulips > 7)
                        {
                            total = total - (total * 0.05);
                        }
                    }
                    if (roses + chrysanthemum + tulips > 20)
                    {
                        total = total - (total * 0.20);
                    }
                    Console.WriteLine($"{total + 2:F2}");
                    break;

                case "Summer":
                    total = chrysanthemum * 2.00 + (roses * 4.10) + (tulips * 2.50);

                    if (holidays == "Y")
                    {
                        total = total + (total * 0.15);
                    }
                    if (roses + chrysanthemum + tulips > 20)
                    {
                        total = total - (total * 0.20);
                    }
                    Console.WriteLine($"{total + 2:F2}");
                    break;
            }

            switch (season)
            {
                case "Winter":
                    total = chrysanthemum * 3.75 + (roses * 4.50) + (tulips * 4.15);

                    if (holidays == "N")
                    {
                        if (roses >= 10)
                        {
                            total = total - (total * 0.10);
                        }
                    }
                    if (holidays == "Y")
                    {
                        total = total + (total * 0.15);
                        if (roses >= 10)
                        {
                            total = total - (total * 0.10);
                        }
                    }
                    if (roses + chrysanthemum + tulips > 20)
                    {
                        total = total - (total * 0.20);
                    }
                    Console.WriteLine($"{total + 2:F2}");
                    break;

                case "Autumn":
                    total = chrysanthemum * 3.75 + (roses * 4.50) + (tulips * 4.15);
                    if (holidays == "Y")
                    {
                        total = total + (total * 0.15);
                    }
                    if (roses + chrysanthemum + tulips > 20)
                    {
                        total = total - (total * 0.20);
                    }
                    Console.WriteLine($"{total + 2:F2}");
                    break;
            }
        }
    }
}
