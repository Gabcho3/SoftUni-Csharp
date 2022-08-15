using System;

namespace T02.EasterGuests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double guests = double.Parse(Console.ReadLine());
            double bujet = double.Parse(Console.ReadLine());

            double neededCakes = Math.Ceiling(guests / 3);
            double neededEggs = guests * 2;
            double priceCakes = neededCakes * 4;
            double priceEggs = neededEggs * 0.45;
            double total = priceCakes + priceEggs;

            if(bujet >= total)
            {
                Console.WriteLine($"Lyubo bought {Math.Ceiling(neededCakes)} Easter bread and {neededEggs} eggs.");
                Console.WriteLine($"He has {bujet - total:f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {total - bujet:f2} lv. more.");
            }
                   
        }
    }
}
