using System;

namespace T04._BackIn30Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hours = int.Parse(Console.ReadLine()); //0-23
            var min = int.Parse(Console.ReadLine()); //0-59
            min += 30;
            if(min >= 60)
            {
                hours++;
                min -= 60;
                if (hours == 24) hours = 0;
            }
            Console.WriteLine($"{hours}:{min:d2}");
        }
    }
}
