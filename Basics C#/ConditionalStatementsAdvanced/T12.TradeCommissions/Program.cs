using System;

namespace T12.TradeCommissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sold = double.Parse(Console.ReadLine());
            bool invalidCity = false;

            if (sold >= 0 && sold <= 500)
            {
                invalidCity = true;
                if (city == "Sofia")
                {
                    Console.WriteLine($"{sold * 0.05:F2}");
                }
                else if (city == "Varna")
                {
                    Console.WriteLine($"{sold * 0.045:F2}");
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine($"{sold * 0.055:F2}");
                }
                else invalidCity = false;
            }

            else if (sold > 500 && sold <= 1000)
            {
                invalidCity = true;
                if (city == "Sofia")
                {
                    Console.WriteLine($"{sold * 0.07:F2}");
                }
                else if (city == "Varna")
                {
                    Console.WriteLine($"{sold * 0.075:F2}");
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine($"{sold * 0.08:F2}");
                }
                else invalidCity = false;
            }

            else if (sold > 1000 && sold <= 10000)
            {
                invalidCity = true;
                if (city == "Sofia")
                {
                    Console.WriteLine($"{sold * 0.08:F2}");
                }
                else if (city == "Varna")
                {
                    Console.WriteLine($"{sold * 0.10:F2}");
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine($"{sold * 0.12:F2}");
                }
                else invalidCity = false;
            }

            else if (sold > 10000)
            {
                invalidCity = true;
                if (city == "Sofia")
                {
                    Console.WriteLine($"{sold * 0.12:F2}");
                }
                else if (city == "Varna")
                {
                    Console.WriteLine($"{sold * 0.13:F2}");
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine($"{sold * 0.145:F2}");
                }
                else invalidCity = false;
            }
            if(!invalidCity || sold < 0)
            {
                Console.WriteLine("error");
                
            }
        }
    }
}
