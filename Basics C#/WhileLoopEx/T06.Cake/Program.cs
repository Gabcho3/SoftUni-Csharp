using System;

namespace T06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int piecesNeeded = length * width; //1x1 one piece
            string input = Console.ReadLine();
            bool cakeFinish = false;

            while (input != "STOP")
            {
                int pieceTake = int.Parse(input);
                piecesNeeded -= pieceTake;
                if(piecesNeeded < 0)
                {
                    cakeFinish = true;
                    break;
                }
                cakeFinish = false;
                input = Console.ReadLine();
            }
            if(cakeFinish)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(piecesNeeded)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{piecesNeeded} pieces are left.");
            }
        }
    }
}
