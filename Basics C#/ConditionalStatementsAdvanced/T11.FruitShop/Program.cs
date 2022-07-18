using System;

namespace T11.FruitShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double num = double.Parse(Console.ReadLine());
            bool valid = false;

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                valid = true;
                if (fruit == "banana")
                {
                    Console.WriteLine($"{num * 2.50:F2}");
                }
                else if (fruit == "apple")
                {
                    Console.WriteLine($"{num * 1.20:F2}");
                }
                else if (fruit == "orange")
                {
                    Console.WriteLine($"{num * 0.85:F2}");
                }
                else if (fruit == "grapefruit")
                {
                    Console.WriteLine($"{num * 1.45:F2}");
                }
                else if (fruit == "kiwi")
                {
                    Console.WriteLine($"{num * 2.70:F2}");
                }
                else if (fruit == "pineapple")
                {
                    Console.WriteLine($"{num * 5.50:F2}");
                }
                else if (fruit == "grapes")
                {
                    Console.WriteLine($"{num * 3.85:F2}");
                }
                else valid = false;
            }

            if (day == "Saturday" || day == "Sunday")
            {
                valid = true;
                if (fruit == "banana")
                {
                    Console.WriteLine($"{num * 2.70:F2}");
                }
                else if (fruit == "apple")
                {
                    Console.WriteLine($"{num * 1.25:F2}");
                }
                else if (fruit == "orange")
                {
                    Console.WriteLine($"{num * 0.90:F2}");
                }
                else if (fruit == "grapefruit")
                {
                    Console.WriteLine($"{num * 1.60:F2}");
                }
                else if (fruit == "kiwi")
                {
                    Console.WriteLine($"{num * 3.00:F2}");
                }
                else if (fruit == "pineapple")
                {
                    Console.WriteLine($"{num * 5.60:F2}");
                }
                else if (fruit == "grapes")
                {
                    Console.WriteLine($"{num * 4.20:F2}");
                }
                else valid = false;
            }
            if (!valid)
            {
                    Console.WriteLine("error");
            }
            
        }
    }
}
