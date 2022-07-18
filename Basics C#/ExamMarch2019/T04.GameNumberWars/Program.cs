using System;

namespace T04.GameNumberWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            string input = Console.ReadLine();

            int points1 = 0;
            int points2 = 0;
            bool numberWars = false;
            string winner = "";
            int winPoints = 0;
            while (input != "End of game")
            {
                int card1 = int.Parse(input);
                int card2 = int.Parse(Console.ReadLine());
                if (card1 == card2)
                {
                    numberWars = true;
                    input = Console.ReadLine();
                    continue;
                }
                if (numberWars)
                {
                    if (card1 > card2) { winner = name1; winPoints = points1; }
                    if (card1 < card2) { winner = name2; winPoints = points2; }
                    break;
                }
                if (card1 > card2) points1 += card1 - card2;
                if (card1 < card2) points2 += card2 - card1;
                input = Console.ReadLine();
            }
            if (numberWars) {Console.WriteLine("Number wars!"); Console.WriteLine($"{winner} is winner with {winPoints} points"); return; }
            Console.WriteLine($"{name1} has {points1} points");
            Console.WriteLine($"{name2} has {points2} points");
        }
    }
}
