using System;

namespace T03.TimePlus15Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            int in15min = min + 15;

            if (hour <= 23 && in15min < 60)
            {
                Console.WriteLine($"{hour}:{in15min}");
            }
            else 
            {
                if (hour == 23) hour = 0;
                else hour += 1;
                in15min -= 60;
                Console.WriteLine($"{hour}:{in15min:d2}");
            }
        }
    }
}
