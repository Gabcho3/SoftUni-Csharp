using System;

namespace T05.GameOfIntervals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double turns = double.Parse(Console.ReadLine());
            double points = 0.00;
            double from0to9 = 0;
            double from10to19 = 0;
            double from20to29 = 0;
            double from30to39 = 0;
            double from40to50 = 0;
            double invalid = 0;

            for(int turn = 1; turn <= turns; turn++)
            {
                int number = int.Parse(Console.ReadLine());
                if(number >= 0 && number < 10)
                {
                    from0to9++;
                    points += number * 0.20;
                }
                if (number >= 10 && number < 20)
                {
                    from10to19++;
                    points += number * 0.30;
                }
                if (number >= 20 && number < 30)
                {
                    from20to29++;
                    points += number * 0.40;
                }
                if (number >= 30 && number < 40)
                {
                    from30to39++;
                    points += 50;
                }
                if (number >= 40 && number <= 50)
                {
                    from40to50++;
                    points += 100;
                }
                if(number < 0 || number > 50)
                {
                    invalid++;
                    points /= 2;
                }
            }
            Console.WriteLine($"{points:F2}");
            Console.WriteLine($"From 0 to 9: {(from0to9 / turns) * 100:f2}% ");
	        Console.WriteLine($"From 10 to 19: {(from10to19 / turns) * 100:f2}%");
            Console.WriteLine($"From 20 to 29: {(from20to29 / turns) * 100:f2}%");
            Console.WriteLine($"From 30 to 39: {(from30to39 / turns) * 100:f2}%");
            Console.WriteLine($"From 40 to 50: {(from40to50 / turns) * 100:f2}%");
            Console.WriteLine($"Invalid numbers: {(invalid / turns) * 100:f2}%");
        }
    }
}
