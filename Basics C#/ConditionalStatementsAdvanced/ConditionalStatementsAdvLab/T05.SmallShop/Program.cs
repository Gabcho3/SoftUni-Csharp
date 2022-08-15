using System;

namespace T05.SmallShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pr = Console.ReadLine();
            string ci = Console.ReadLine();
            double tot = double.Parse(Console.ReadLine());

            if (ci == "Sofia")
            {
                if (pr == "coffee")
                {
                    Console.WriteLine(tot * 0.50);
                }
                else if (pr == "water")
                {
                    Console.WriteLine(tot * 0.80);
                }
                else if (pr == "beer")
                {
                    Console.WriteLine(tot * 1.20);
                }
                else if (pr == "sweets")
                {
                    Console.WriteLine(tot * 1.45);
                }
                else if (pr == "peanuts")
                {
                    Console.WriteLine(tot * 1.60);
                }
            }

            if (ci == "Plovdiv")
            {
                if (pr == "coffee")
                {
                    Console.WriteLine(tot * 0.40);
                }
                else if (pr == "water")
                {
                    Console.WriteLine(tot * 0.70);
                }
                else if (pr == "beer")
                {
                    Console.WriteLine(tot * 1.15);
                }
                else if (pr == "sweets")
                {
                    Console.WriteLine(tot * 1.30);
                }
                else if (pr == "peanuts")
                {
                    Console.WriteLine(tot * 1.50);
                }
            }

            if (ci == "Varna")
            {
                if (pr == "coffee")
                {
                    Console.WriteLine(tot * 0.45);
                }
                else if (pr == "water")
                {
                    Console.WriteLine(tot * 0.70);
                }
                else if (pr == "beer")
                {
                    Console.WriteLine(tot * 1.10);
                }
                else if (pr == "sweets")
                {
                    Console.WriteLine(tot * 1.35);
                }
                else if (pr == "peanuts")
                {
                    Console.WriteLine(tot * 1.55);
                }
            }
        }
    }
}
