using System;

namespace T05.TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double wCm = w * 100;
            double hCm = h * 100;

            double withoutcoridor = hCm - 100;
            double deskonrow = withoutcoridor % 70;
            double deskonrow1 = withoutcoridor - deskonrow;
            double deskonrow2 = deskonrow1 / 70;
            double row = wCm % 120 ;
            double row1 = wCm - row;
            double row2 = row1 / 120;

            double places = (deskonrow2 * row2) - 3;
            Console.WriteLine($"{places}");
        }
    }
}
