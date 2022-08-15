using System;

namespace T02.Skeleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double minutesControl = int.Parse(Console.ReadLine()) * 60; //* 60 --> to seconds
            double secondsControl = int.Parse(Console.ReadLine());
            double timeControl = minutesControl + secondsControl;
            double length = double.Parse(Console.ReadLine());
            double secondsFor100metres = int.Parse(Console.ReadLine());

            double decreases = length / 120; //how many times time will decreases
            double totalDecreases = decreases * 2.5; //total seconds which will be decreases
            double timeMartin = ((length / 100.0) * secondsFor100metres) - totalDecreases;

            if (timeMartin <= timeControl)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {timeMartin:f3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {timeMartin - timeControl:f3} second slower.");
            }
        }
    }
}
