using System;

namespace T02.BikeRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            double tax = 0.00;
            double costs = 0.00;
            double total = 0.00;

            switch(type)
            {
                case "trail":
                    tax = juniors * 5.50 + (seniors * 7.00);
                    costs = tax - (tax * 0.05);
                    break;

                case "cross-country":
                    tax = juniors * 8.00 + (seniors * 9.50);
                    costs = tax - (tax * 0.05);

                    if(juniors + seniors >= 50)
                    {
                        tax = tax - (tax * 0.25);
                        costs = tax - (tax * 0.05);
                    }
                    break;

                case "downhill":
                    tax = juniors * 12.25 + (seniors * 13.75);
                    costs = tax - (tax * 0.05);
                    break;

                case "road":
                    tax = juniors * 20.00 + (seniors * 21.50);
                    costs = tax - (tax * 0.05);
                    break;
            }
            Console.WriteLine($"{costs:F2}");
        }
    }
}
