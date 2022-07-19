using System;

namespace T08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kegs = int.Parse(Console.ReadLine());
            double bigestKegVolume = int.MinValue;
            string biggestKeg = string.Empty; //Must print the model of the BIGGEST keg

            for(int keg = 1; keg <= kegs ; keg++) { //we have 3 INPUTS for every keg
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * height; //formula of VOLUME
                if (volume > bigestKegVolume) {
                    bigestKegVolume = volume;
                    biggestKeg = model;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
