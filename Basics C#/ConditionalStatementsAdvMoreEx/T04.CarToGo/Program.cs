using System;

namespace T04.CarToGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double price = 0.00;
            string clas;
            string type;

            if (bujet <= 100)
            {
                clas = "Economy class";
                if (season == "Summer")
                {
                    type = "Cabrio";
                    price = bujet * 0.35;
                }
                else
                {
                    type = "Jeep";
                    price = bujet * 0.65;
                }
                Console.WriteLine(clas);
                Console.WriteLine($"{type} - {price:F2}");
            }

            if (bujet > 100 & bujet <= 500)
            {
                clas = "Compact class";
                if (season == "Summer")
                {
                    type = "Cabrio";
                    price = bujet * 0.45;
                }
                else
                {
                    type = "Jeep";
                    price = bujet * 0.80;
                }
                Console.WriteLine(clas);
                Console.WriteLine($"{type} - {price:F2}");
            }

            if (bujet > 500)
            {
                clas = "Luxury class";
                type = "Jeep";
                price = bujet * 0.90;

                Console.WriteLine(clas);
                Console.WriteLine($"{type} - {price:F2}");
            }
        }
    }
}
