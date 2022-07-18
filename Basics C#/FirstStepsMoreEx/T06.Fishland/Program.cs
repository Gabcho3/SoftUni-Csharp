using System;

namespace T06.Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double prskum = double.Parse(Console.ReadLine());
            double prcaca = double.Parse(Console.ReadLine());
            double kgpalm = double.Parse(Console.ReadLine());
            double kgsafr = double.Parse(Console.ReadLine());
            int kgmidi = int.Parse(Console.ReadLine());

            double prpalm = kgpalm * (prskum + (prskum * 0.60));
            double prsafr = kgsafr * (prcaca + (prcaca * 0.80));
            double prmidi = kgmidi * 7.50;
            double tot = prpalm + prsafr + prmidi;
            Console.WriteLine($"{tot:F2}");

        }
    }
}
