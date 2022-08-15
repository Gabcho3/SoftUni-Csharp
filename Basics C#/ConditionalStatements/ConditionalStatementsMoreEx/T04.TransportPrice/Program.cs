using System;

namespace T04.TransportPrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int km = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();

            if (dayOrNight == "day" && km < 20)
            {
                double taxi = 0.70 + (km * 0.79);
                Console.WriteLine($"{taxi:F2}");
            }
            if(dayOrNight == "night" && km < 20)
            {
                double taxi = 0.70 + (km * 0.90);
                Console.WriteLine($"{taxi:F2}");
            }
            if(km >= 20 & km < 100)
            { 
                double bus = 0.09 * km;
                Console.WriteLine($"{bus:F2}");
            }
            if(km >= 100)
            {
                double train = 0.06 * km;
                Console.WriteLine($"{train:F2}");
            }
        }
    }
}
