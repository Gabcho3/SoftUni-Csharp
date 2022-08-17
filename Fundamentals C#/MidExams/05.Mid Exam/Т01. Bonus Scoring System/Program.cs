using System;

namespace Т01._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double topattendance = 0;
            double maxBonus = 0;

            for (int i = 0; i < students; i++)
            {
                double attendance = double.Parse(Console.ReadLine());

                double bonus = attendance / lectures * (5 + additionalBonus);

                if(bonus > maxBonus)
                {
                    maxBonus = bonus;
                    topattendance = attendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {topattendance} lectures.");
        }
    }
}
