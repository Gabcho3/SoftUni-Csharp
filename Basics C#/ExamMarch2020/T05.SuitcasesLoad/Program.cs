using System;

namespace T05.SuitcasesLoad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int counter = 0;
            bool isLoaded = false;

            while(input != "End")
            {
                isLoaded = true;
                double luggage = double.Parse(input);
                counter++;
                if(counter % 3 ==0)
                {
                    luggage += luggage * 0.10;
                }
                capacity -= luggage;
                if(capacity <= 0)
                {
                    isLoaded = false;
                    counter--;
                    break;
                }
                input = Console.ReadLine();
            }
            if(isLoaded)
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }
            else
            {
                Console.WriteLine("No more space!");
            }
                Console.WriteLine($"Statistic: {counter} suitcases loaded.");
        }
    }
}
