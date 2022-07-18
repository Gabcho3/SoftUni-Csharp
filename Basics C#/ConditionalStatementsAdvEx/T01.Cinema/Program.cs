using System;

namespace T01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (type == "Premiere")
            {
                Console.WriteLine($"{r * c * 12.00:F2} leva");
            }
            if (type == "Normal")
            {
                Console.WriteLine($"{r * c * 7.50:F2} leva");
            }
            if (type == "Discount")
            {
                Console.WriteLine($"{r * c * 5.00:F2} leva");
            }
        }
    }
}
