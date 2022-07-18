using System;

namespace T05.TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double wcm = w * 100;
            double hcm = h * 100;

            double withoutcoridor = hcm - 100;
            double deskonrow = withoutcoridor % 70;
            double deskonrow1 = withoutcoridor - deskonrow;
            double deskonrow2 = deskonrow1 / 70;
            double row = wcm % 120 ;
            double row1 = wcm - row;
            double row2 = row1 / 120;

            double places = (deskonrow2 * row2) - 3;
            Console.WriteLine($"{places}");
        }
    }
}
