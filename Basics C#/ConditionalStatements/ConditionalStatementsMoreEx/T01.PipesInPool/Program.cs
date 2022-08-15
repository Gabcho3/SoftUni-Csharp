using System;

namespace T01.PipesInPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int V = int.Parse(Console.ReadLine());
            int P1 = int.Parse(Console.ReadLine());
            int P2 = int.Parse(Console.ReadLine());
            double H = double.Parse(Console.ReadLine());

            double p1L = P1 * H;
            double p2L = P2 * H;
            double L = p1L + p2L;
            double percentage = (L / V) * 100.0;
            double percentageP1 = (p1L / L) * 100.0;
            double percentageP2 = (p2L / L) * 100.0;
            if (V >= L)
            {
                Console.WriteLine($"The pool is {percentage:F2}% full. Pipe 1: {percentageP1:F2}%. Pipe 2: {percentageP2:F2}%.");
            }
            else
            {
                Console.WriteLine($"For {H} hours the pool overflows with {L - V:F2} liters");
            }
        }
    }
}
