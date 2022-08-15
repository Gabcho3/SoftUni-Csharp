using System;

namespace T01.Dishwasher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bottlesOfDetergent = int.Parse(Console.ReadLine());
            int totalMl = bottlesOfDetergent * 750;
            string input = Console.ReadLine();

            bool detergrentEND = false;
            int dishes = 0;
            int pots = 0;
            int times = 0;
            int spentMl = 0;

            while(input != "End")
            {
                detergrentEND = false;
                times++;
                int washed = int.Parse(input);
                if(times % 3 == 0)
                {
                    pots += washed;
                }
                else
                {
                    dishes += washed;
                }
                spentMl = dishes * 5 + pots * 15;
                if(totalMl < spentMl)
                {
                    detergrentEND = true;
                    break;
                }
                input = Console.ReadLine();
            }

            if(detergrentEND)
            {
                Console.WriteLine($"Not enough detergent, {spentMl - totalMl} ml. more necessary!");
            }
            else
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{dishes} dishes and {pots} pots were washed.");
                Console.WriteLine($"Leftover detergent {totalMl - spentMl} ml.");
            }
        }
    }
}
