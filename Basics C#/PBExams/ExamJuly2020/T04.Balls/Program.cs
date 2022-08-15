using System;

namespace T04.Balls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int balls = int.Parse(Console.ReadLine());
            double points = 0;
            int red = 0;
            int orange = 0;
            int yellow = 0;
            int white = 0;
            int black = 0;
            int others = 0;

            for(int color = 1; color <= balls; color++)
            {
                string colors = Console.ReadLine();
                if (colors == "red")
                {
                    red++; points += 5;
                }
                else if (colors == "orange")
                {
                    orange++; points += 10;
                }
                else if (colors == "yellow")
                {
                    yellow++; points += 15;
                }
                else if (colors == "white")
                {
                    white++; points += 20;
                }
                else if (colors == "black")
                {
                    black++; points /= 2;
                }
                else
                {
                    others++;
                }
            }
            Console.WriteLine($"Total points: {Math.Floor(points)}");
            Console.WriteLine($"Red balls: {red}");
            Console.WriteLine($"Orange balls: {orange}");
            Console.WriteLine($"Yellow balls: {yellow}");
            Console.WriteLine($"White balls: {white}");
            Console.WriteLine($"Other colors picked: {others}");
            Console.WriteLine($"Divides from black balls: {black}");
        }
    }
}

