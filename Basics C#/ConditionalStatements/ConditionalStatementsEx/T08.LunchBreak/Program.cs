using System;

namespace T08.LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int min = int.Parse(Console.ReadLine());
            int break1 = int.Parse(Console.ReadLine());

            double lunch = break1 * (1.00 / 8.00);
            double relax = break1 * (1.00 / 4.00);

            double last = break1 - lunch - relax;

            if (last >= min)
            {
                Console.WriteLine($"You have enough time to watch {name} and left with {Math.Ceiling(last - min)} minutes free time.");
            }
            else if (last < min)
            {
                Console.WriteLine($"You don't have enough time to watch {name}, you need {Math.Ceiling(min - last)} more minutes.");
            }
        }
    }
}
