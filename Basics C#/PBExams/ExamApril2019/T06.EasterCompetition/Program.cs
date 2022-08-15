using System;

namespace T06.EasterCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cakes = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            string currentName = "";
            int points = int.Parse(Console.ReadLine());
            int number1 = int.MinValue;
            string winner = "";

            for(int cake = 1; cake <= cakes; cake++)
            {
                currentName = name;
                while(name != "Stop")
                {
                    name = Console.ReadLine();
                    if(name == "Stop")
                    {
                        break;
                    }
                    points += int.Parse(name);
                }
                Console.WriteLine($"{currentName} has {points} points.");
                if(points > number1)
                {
                    number1 = points;
                    Console.WriteLine($"{currentName} is the new number 1!");
                    winner = currentName;
                }
                points = 0;
                if (cake < cakes)
                {
                    name = Console.ReadLine();
                }
            }
            Console.WriteLine($"{winner} won competition with {number1} points!");
        }
    }
}
