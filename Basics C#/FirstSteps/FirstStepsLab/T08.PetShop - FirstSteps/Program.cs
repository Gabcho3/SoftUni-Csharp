using System;

namespace T08.PetShop___FirstSteps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int cats = int.Parse(Console.ReadLine());
            double prdog = dogs * 2.50;
            int prcat = cats * 4;
            double total = prdog + prcat;
            Console.WriteLine(total + " " + "lv.");

        }
    }
}
