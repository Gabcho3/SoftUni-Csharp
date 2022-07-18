using System;

namespace T05.Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination;
            double minBujet, saving;
            bool endLoop = false;

            while(!endLoop)
            {
                destination = Console.ReadLine();
                if (destination == "End")
                {
                    endLoop = true;
                }
                else
                {
                    minBujet = double.Parse(Console.ReadLine());
                    while(minBujet > 0)
                    {
                        saving = double.Parse(Console.ReadLine());
                        minBujet -= saving;
                    }
                    Console.WriteLine($"Going to {destination}!");
                }
            }
        }
    }
}
