using System;

namespace Т06.NameGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfPlayer = Console.ReadLine();

            string winner = null;
            int points = 0;
            int maxPoints = int.MinValue;

            while(nameOfPlayer != "Stop")
            {
                int length = nameOfPlayer.Length;
                for(int i = 0; i < length; i++)
                {
                    int number = int.Parse(Console.ReadLine());
                    if (number == (char)nameOfPlayer[i])
                        points += 10;
                    else
                        points += 2;
                }
                if (points >= maxPoints)
                {
                    winner = nameOfPlayer;
                    maxPoints = points;
                }

                points = 0;
                nameOfPlayer = Console.ReadLine();
            }
            Console.WriteLine($"The winner is {winner} with {maxPoints} points!");
        }
    }
}
