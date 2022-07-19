using System;

namespace T07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //capacity of tank is 255 liters
            //no more than 255 liters
            int lines = int.Parse(Console.ReadLine());
            int totalLiters = 0;
            for(int i = 0; i < lines; i++) { 
                int liters = int.Parse(Console.ReadLine());
                totalLiters += liters;
                if(totalLiters > 255) {
                    Console.WriteLine("Insufficient capacity!");
                    totalLiters -= liters; //liters are more and don't count
                }
            }
            Console.WriteLine(totalLiters);
        }
    }
}
