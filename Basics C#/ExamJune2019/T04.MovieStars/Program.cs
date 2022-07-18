using System;

namespace T04.MovieStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double actorsBujet = double.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            double reward = 0;
            bool noMoney = false;
            while(name != "ACTION")
            {
                int nameLength = name.Length;
                if (nameLength > 15) reward = actorsBujet * 0.20;
                else
                {
                    reward = double.Parse(Console.ReadLine());
                }
                
                actorsBujet -= reward;
                if (actorsBujet <= 0)
                {
                    noMoney = true;
                    break;
                }
                name = Console.ReadLine();
            }
            if (noMoney) Console.WriteLine($"We need {Math.Abs(actorsBujet):f2} leva for our actors.");
            else Console.WriteLine($"We are left with {actorsBujet:f2} leva.");
        }
    }
}


