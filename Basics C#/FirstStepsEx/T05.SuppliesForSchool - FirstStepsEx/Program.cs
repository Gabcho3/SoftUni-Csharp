using System;

namespace T05.SuppliesForSchool___FirstStepsEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int pe = int.Parse(Console.ReadLine());
            double dis = pe / 100.00;
            double pricep = p * 5.80;
            double pricem = m * 7.20;
            double pricel = l * 1.20;
            double price = pricep + pricem + pricel;
            double total = price - (price * dis);
            Console.WriteLine(total);
        }
    }
}
