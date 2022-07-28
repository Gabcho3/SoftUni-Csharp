using System;
using System.Linq;

namespace T09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sequencesLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int[] sequense = new int[sequencesLength];
            int[] DNA = new int[sequencesLength];

            int currDNAsum = 0;
            int maxSum = 0;

            int maxCount = -1; //count can be 0 {no DNA}
            int bestStartIndex = -1; //index can be 0

            int sample = 0;
            int bestSample = 0;

            while (input != "Clone them!")
            {
                sequense = input
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sample++;
                //DNA ELEMENTS
                int currStartIndex = 0;
                int currEndIndex = 0;
                int dnaCount = 0;
                bool isBetter = false;

                int currCount = 0;
                for (int i = 0; i < sequencesLength; i++)
                {
                    if (sequense[i] != 1)
                    {
                        currCount = 0;
                        continue;
                    }

                    currCount++; //count of all numbers ONE in sequence 
                    if (currCount > dnaCount)
                    {
                        dnaCount = currCount;
                        currEndIndex = i;
                    }
                }
                currStartIndex = currEndIndex - dnaCount + 1;
                currDNAsum = sequense.Sum();

                if (dnaCount > maxCount)
                {
                    isBetter = true;
                }   

                else if (dnaCount == maxCount)
                {
                    if (currStartIndex < bestStartIndex)
                        isBetter = true;

                    else if (currStartIndex == bestStartIndex)
                    {
                        if (currDNAsum > maxSum)
                            isBetter = true;
                    }
                }

                if(isBetter)
                {
                    maxSum = currDNAsum;
                    maxCount = dnaCount;

                    bestStartIndex = currStartIndex;
                    bestSample = sample;
                    DNA = sequense;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSample} with sum: {maxSum}.");
            Console.WriteLine(string.Join(" ", DNA));
        }
    }
}
