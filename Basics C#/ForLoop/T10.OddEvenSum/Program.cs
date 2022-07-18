using System;

namespace T10.OddEvenSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 != 0)
                {
                int oddNumber = int.Parse(Console.ReadLine());
                    oddSum += oddNumber;
                }
                if (i % 2 == 0)
                {
                int evenNumber = int.Parse((Console.ReadLine()));
                    evenSum += evenNumber;
                }
            }
            
            if(oddSum == evenSum)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {oddSum}");
            }
            else
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {Math.Abs(evenSum - oddSum)}");
            }   
        }
    }
}
