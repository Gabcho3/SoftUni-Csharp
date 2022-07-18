using System;

namespace T04.Renovation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hight = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            double percentWithoutPainting = double.Parse(Console.ReadLine()) / 100;
            string input = Console.ReadLine();
            int area = hight * width * 4; //4 --> 4 walls
            double painting = 0;
            painting = Math.Ceiling(area - (area * percentWithoutPainting));
            bool noMorePaint = false;
            bool remainingPaint = false;
            while(input != "Tired!")
            {
                int liters = int.Parse(input);
                painting -= liters;
                if(painting == 0)
                {
                    noMorePaint = true;
                    break;
                }
                if(painting < 0)
                {
                    remainingPaint = true;
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "Tired!") Console.WriteLine($"{painting} quadratic m left.");
            if (remainingPaint) Console.WriteLine($"All walls are painted and you have {Math.Abs(painting)} l paint left!"); //Math.Abs --> painting is negative
            if (noMorePaint) Console.WriteLine($"All walls are painted! Great job, Pesho!");
        }
    }
}
