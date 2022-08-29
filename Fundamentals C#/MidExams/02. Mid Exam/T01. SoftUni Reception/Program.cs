using System;

namespace T01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int efficiency1 = int.Parse(Console.ReadLine());
            int efficiency2 = int.Parse(Console.ReadLine());
            int efficiency3 = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());

            int hours = 0;

            while (students > 0)
            {
                hours++;

                if (hours % 4 == 0)
                    hours++;

                students -= efficiency1 + efficiency2 + efficiency3;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
