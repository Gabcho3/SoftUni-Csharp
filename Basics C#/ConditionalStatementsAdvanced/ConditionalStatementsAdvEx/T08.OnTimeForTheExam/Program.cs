using System;

namespace T08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 90 % 60;

            int exh = int.Parse(Console.ReadLine()); //0-23
            int exm = int.Parse(Console.ReadLine()); //0-59
            int arh = int.Parse(Console.ReadLine()); //0-23
            int arm = int.Parse(Console.ReadLine()); //0-59
                                                     //правим всичко в минути
            int totminex = exh * 60 + exm; //10 * 60 + 30 == 630
            int totminar = arh * 60 + arm; //11 * 60 + 00 = 660
            int diff = totminex - totminar; //late: -num ; on: 0 ; early: +num
            int min = diff % 60;
            int hour = diff / 60;

            if (diff == 0)
            {
                Console.WriteLine("On time");
            }
            else if (diff > 0 && diff <= 30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{min} minutes before the start");
            }
            else if (diff > 30 && diff < 60)
            {
                Console.WriteLine("Early");
                Console.WriteLine($"{min} minutes before the start");
            }
            else if (diff >= 60)
            {
                Console.WriteLine("Early");
                Console.WriteLine($"{hour}:{min:D2} hours before the start");
            }
            else if (diff < 0 && diff > -60)
            {
                Console.WriteLine("Late");
                Console.WriteLine($"{- min} minutes after the start");
            }
            else if (diff <= -60)
            {
                Console.WriteLine("Late");
                Console.WriteLine($"{-hour}:{-min:D2} hours after the start");
            }
        }
    }
}
