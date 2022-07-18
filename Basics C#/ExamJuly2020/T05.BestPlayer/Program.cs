using System;

namespace T05.BestPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string namePlayer = Console.ReadLine();
            string bestPlayer = "";
            int mostGoals = int.MinValue;
            bool haveHatTrick = false;
            while(namePlayer != "END")
            {
                int goals = int.Parse(Console.ReadLine());
                if(goals > mostGoals)
                {
                    mostGoals = goals;
                    bestPlayer = namePlayer;
                }
                if(goals >= 3)
                {
                    haveHatTrick = true;
                }
                if(goals >= 10)
                {
                    break;
                }
                namePlayer = Console.ReadLine();
            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if(haveHatTrick)
            {
                Console.WriteLine($"He has scored {mostGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {mostGoals} goals.");
            }
        }
    }
}
