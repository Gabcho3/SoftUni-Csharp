using System;

namespace T13._Prime_Pairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start1 = int.Parse(Console.ReadLine());
            int start2 = int.Parse(Console.ReadLine());
            int diff1 = int.Parse(Console.ReadLine());
            int diff2 = int.Parse(Console.ReadLine());

            int max1 = start1 + diff1;
            int max2 = start2 + diff2;


            for (int first = start1; first <= max1; first++)
            {
                bool isPrime1 = true;
                bool isPrime2 = true;
                for(int divider1 = 2; divider1 < first; divider1++) //check if first pair is PRIME
                {
                    if (first % divider1 == 0)
                    {
                        isPrime1 = false;
                        break;
                    }
                    else
                        isPrime1 = true; 
                }
                if (!isPrime1)
                    continue;
                for (int second = start2; second <= max2; second++)
                {
                    for (int divider2 = 2; divider2 < second; divider2++) //check if second pair is PRIME
                    {
                        if (second % divider2 == 0)
                        {
                            isPrime2 = false;
                            break;
                        }
                        else
                            isPrime2 = true;
                    }
                    if (isPrime1 && isPrime2)
                        Console.WriteLine("{0}{1}", first, second);
                }
            }

        }
    }
}
