using System;

namespace T09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceOfLightsaber = double.Parse(Console.ReadLine());
            double priceOfRobe = double.Parse(Console.ReadLine());
            double priceOfBelt = double.Parse(Console.ReadLine());

            double sumForLightsabers = (students + Math.Ceiling(students * 0.10)) * priceOfLightsaber; //lightsabres sometimes break
            double sumForRobes = students * priceOfRobe;
            double sumForBels = students * priceOfBelt;
            for (int belt = 1; belt <= students; belt++)
            {
                if (belt % 6 == 0) sumForBels -= priceOfBelt; //every sixth belt is free
            }
            double total = sumForLightsabers + sumForRobes + sumForBels;
            if (bujet >= total) Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            else Console.WriteLine($"John will need {total - bujet:f2}lv more.");
        }
    }
}
