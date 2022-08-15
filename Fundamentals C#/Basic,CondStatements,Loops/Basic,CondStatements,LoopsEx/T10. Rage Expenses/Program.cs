using System;

namespace T10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lost = int.Parse(Console.ReadLine());
            double priceHeadset = double.Parse(Console.ReadLine());
            double priceMouse = double.Parse(Console.ReadLine());
            double priceKeyboeard = double.Parse(Console.ReadLine());
            double priceDisplay = double.Parse(Console.ReadLine());

            int headsetCount = 0;
            int mouseCount = 0;
            double keyboardCount = 0;
            int displayCount = 0;
            int keyboard = 0; //specific count to COUNT broken displays
            for (int lostGame = 1; lostGame <= lost; lostGame++)
            {
                if (lostGame % 2 == 0) headsetCount++;
                if (lostGame % 3 == 0) mouseCount++;
                if (lostGame % 6 == 0) //intersect at 6
                {
                    keyboardCount++; 
                    keyboard++;
                }
                if (keyboard == 2) 
                {
                    displayCount++;
                    keyboard = 0; //<-- for not always enter the loop
                }
            }
            double totalHeadsets = priceHeadset * headsetCount;
            double totalMouses = priceMouse * mouseCount;
            double totalKeyboards = priceKeyboeard * keyboardCount;
            double totalDisplays = priceDisplay * displayCount;
            double sum = totalHeadsets + totalMouses + totalKeyboards + totalDisplays;
            Console.WriteLine($"Rage expenses: {sum:f2} lv.");
        }
    }
}
