﻿using System;

namespace T01.TrapeziodArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double area = (b1 + b2) * h / 2;
            Console.WriteLine($"{area:F2}");
        }
    }
}