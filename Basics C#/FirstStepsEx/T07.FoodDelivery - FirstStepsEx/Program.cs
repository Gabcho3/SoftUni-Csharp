using System;

namespace T07.FoodDelivery___FirstStepsEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ch = int.Parse(Console.ReadLine());
            int fi = int.Parse(Console.ReadLine());
            int vg = int.Parse(Console.ReadLine());
            double prch = ch * 10.35;
            double prfi = fi * 12.40;
            double prvg = vg * 8.15;
            double ds = (prch + prfi + prvg) * 0.20;
            double total = prch + prfi + prvg + ds + 2.50;
            Console.WriteLine(total);
        }
    }
}
