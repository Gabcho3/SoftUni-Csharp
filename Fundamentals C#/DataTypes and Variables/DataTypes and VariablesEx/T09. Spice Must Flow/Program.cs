using System;

namespace T09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Must print two separate lines how many DAYS the mine has operated and the TOTAL amount of spice extracted.
            int startingYeild = int.Parse(Console.ReadLine());
            int days = 0;
            int total = 0;
            while(startingYeild >= 100) { //if less than 100 per day, we abandon then source
                days++;
                total += startingYeild;
                total -= 26; //workers consume 26 spices per day
                startingYeild -= 10; //the yeild drops 10 every day
            }
            if (total >= 26){ //workers CANNOT consume more spice than there is in storage
                total -= 26; //Since the expected yield is  LESS than 100, we abandon the source. The workers take ANOTHER 26
            } 
            Console.WriteLine(days);
            Console.WriteLine(total);
        }
    }
}
