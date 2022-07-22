using System;

namespace T02.LettersCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char skip = char.Parse(Console.ReadLine());

            int count = 0;

            for (char first = start; first <= end; first++)
            {
                if (first == skip)
                    continue;
                for (char second = start; second <= end; second++)
                {
                    if (second == skip)
                        continue;
                    for (char third = start; third <= end; third++)
                    {
                        if (third == skip)
                            continue;
                        Console.Write($"{first}{second}{third} ");
                        count++;
                    }
                }
            }
            Console.Write(count);
        }
    }
}
