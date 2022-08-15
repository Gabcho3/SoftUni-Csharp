using System;

namespace T04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bj = int.Parse(Console.ReadLine());
            string se = Console.ReadLine();
            int tot = int.Parse(Console.ReadLine());
            double rent = 0.00;

            switch (se)
            {
                case "Spring":
                    rent = 3000;
                    if (tot <= 6 && tot % 2 == 0)
                    {
                        rent = rent - (rent * 0.10);
                        rent = rent + (rent * 0.05);
                    }
                    if (tot >= 7 && tot <= 11 && tot % 2 == 0)
                    {
                        rent = rent - (rent * 0.15);
                        rent = rent - (rent * 0.05);
                    }
                    if (tot >= 12 && tot % 2 == 0)
                    {
                        rent = rent - (rent * 0.25);
                        rent = rent - (rent * 0.05);
                    }

                    if (tot <= 6 && tot % 2 != 0)
                    {
                        rent = rent - (rent * 0.10);
                    }
                    if (tot >= 7 && tot <= 11 && tot % 2 != 0)
                    {
                        rent = rent - (rent * 0.15);
                    }
                    if (tot >= 12 && tot % 2 != 0)
                    {
                        rent = rent - (rent * 0.25);

                    }
                    break;

                case "Summer":
                    rent = 4200;
                    if (tot <= 6 && tot % 2 == 0)
                    {
                        rent = rent - (rent * 0.10);
                        rent = rent - (rent * 0.05);
                    }
                    if (tot >= 7 && tot <= 11 && tot % 2 == 0)
                    {
                        rent = rent - (rent * 0.15);
                        rent = rent - (rent * 0.05);
                    }
                    if (tot >= 12 && tot % 2 == 0)
                    {
                        rent = rent - (rent * 0.25);
                        rent = rent - (rent * 0.05);
                    }

                    if (tot <= 6 && tot % 2 != 0)
                    {
                        rent = rent - (rent * 0.10);
                    }
                    if (tot >= 7 && tot <= 11 && tot % 2 != 0)
                    {
                        rent = rent - (rent * 0.15);
                    }
                    if (tot >= 12 && tot % 2 != 0)
                    {
                        rent = rent - (rent * 0.25);
                    }
                    break;

                case "Autumn":

                    rent = 4200;
                    if (tot <= 6)
                    {
                        rent = rent - (rent * 0.10);
                    }
                    if (tot >= 7 && tot <= 11)
                    {
                        rent = rent - (rent * 0.15);
                    }
                    if (tot >= 12)
                    {
                        rent = rent - (rent * 0.25);
                    }
                    break;

                case "Winter":

                    rent = 2600;
                    if (tot <= 6 && tot % 2 == 0)
                    {
                        rent = rent - (rent * 0.10);
                        rent = rent - (rent * 0.05);
                    }
                    if (tot >= 7 && tot <= 11 && tot % 2 == 0)
                    {
                        rent = rent - (rent * 0.15);
                        rent = rent - (rent * 0.05);
                    }
                    if (tot >= 12 && tot % 2 == 0)
                    {
                        rent = rent - (rent * 0.25);
                        rent = rent - (rent * 0.05);
                    }

                    if (tot <= 6 && tot % 2 != 0)
                    {
                        rent = rent - (rent * 0.10);
                    }
                    if (tot >= 7 && tot <= 11 && tot % 2 != 0)
                    {
                        rent = rent - (rent * 0.15);
                    }
                    if (tot >= 12 && tot % 2 != 0)
                    {
                        rent = rent - (rent * 0.25);
                    }
                    break;
            }
                    if (rent <= bj)
                    {
                        Console.WriteLine($"Yes! You have {bj - rent:F2} leva left.");
                    }
                    if (rent > bj)
                    {
                        Console.WriteLine($"Not enough money! You need {rent - bj:F2} leva.");
                    }
        }
    }
}
