using System;

namespace T03.NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flo = Console.ReadLine();
            int tot = int.Parse(Console.ReadLine());
            int buj = int.Parse(Console.ReadLine());
            double price = 0.00;

            if (flo == "Roses")
            {

                if (tot <= 80)
                {
                    price = tot * 5.00;
                }
                else if (tot > 80)
                {
                    price = tot * 5.00 - (tot * 5.00 * 0.10);
                }
                if (buj >= price)
                {
                    Console.WriteLine($"Hey, you have a great garden with {tot} {flo} and {buj - price:F2} leva left.");
                }
                if (buj < price)
                {
                    Console.WriteLine($"Not enough money, you need {price - buj:F2} leva more.");
                }
            }

            if (flo == "Dahlias")
            {
                price = tot * 3.80;
                if (tot <= 90)
                {
                    price = tot * 3.80;
                }

                else if (tot > 90)
                {
                    price = tot * 3.80 - (tot * 3.80 * 0.15);
                }
                if (buj >= price)
                {
                    Console.WriteLine($"Hey, you have a great garden with {tot} {flo} and {buj - price:F2} leva left.");
                }
                if (buj < price)
                {
                    Console.WriteLine($"Not enough money, you need {price - buj:F2} leva more.");
                }

            }

            if (flo == "Tulips")
            {
                price = tot * 2.80;
                if (tot <= 80)
                {
                    price = tot * 2.80;
                }


                else if (tot > 80)
                {
                    price = tot * 2.80 - (tot * 2.80 * 0.15);
                }
                if (buj >= price)
                {
                    Console.WriteLine($"Hey, you have a great garden with {tot} {flo} and {buj - price:F2} leva left.");
                }
                if (buj < price)
                {
                    Console.WriteLine($"Not enough money, you need {price - buj:F2} leva more.");
                }
            }


            if (flo == "Narcissus")
            {
                price = tot * 3.00;
                if (tot >= 120)
                {
                    price = tot * 3.00;
                }


                else if (tot < 120)
                {
                    price = tot * 3.00 + (tot * 3.00 * 0.15);
                }
                if (buj >= price)
                {
                    Console.WriteLine($"Hey, you have a great garden with {tot} {flo} and {buj - price:F2} leva left.");
                }
                if (buj < price)
                {
                    Console.WriteLine($"Not enough money, you need {price - buj:F2} leva more.");
                }
            }

            if (flo == "Gladiolus")
            {

                if (tot >= 80)
                {
                    price = tot * 2.50;
                }

                else if (tot < 80)
                {
                    price = tot * 2.50 + (tot * 2.50 * 0.20);
                }
                if (buj >= price)
                {
                    Console.WriteLine($"Hey, you have a great garden with {tot} {flo} and {buj - price:F2} leva left.");
                }
                if (buj < price)
                {
                    Console.WriteLine($"Not enough money, you need {price - buj:F2} leva more.");
                }
            }
        }
    }
}
