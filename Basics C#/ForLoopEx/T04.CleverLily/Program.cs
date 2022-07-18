using System;

namespace T04.CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double wash = double.Parse(Console.ReadLine());
            int sumForOneToy = int.Parse(Console.ReadLine());
            double sum = 0;
            int toys = 0;
            int sumGift = 10; //first sum
            for(int i = 1; i <=age; i++)
            {
                if (i % 2 != 0)
                {
                    toys++;
                }
                else
                {
                    sum += sumGift; //total sum
                    sum--; //for brother
                    sumGift += 10; //every time +10lv
                }
            }
            double sumForToys = toys * sumForOneToy;
            double total = sum + sumForToys;
                
            if(total >= wash)
            {
                Console.WriteLine($"Yes! {total - wash:F2}");
            }
            else
            {
                Console.WriteLine($"No! {wash - total:F2}"); 
            }
        }
    }
}
