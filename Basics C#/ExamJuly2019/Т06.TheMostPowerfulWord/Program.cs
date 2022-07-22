using System;

namespace Т06.TheMostPowerfulWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string strongestWord = null;
            decimal sumOfWord = 0; // because of Math.Floor()
            decimal maxSum = int.MinValue;

            while (word != "End of words")
            {
                int length = word.Length;
                for (int i = 0; i < length; i++)
                {
                    sumOfWord += (int)word[i];
                }

                char firstLetter = word[0];

                if (firstLetter == 'A' || firstLetter == 'E' || firstLetter == 'I' || firstLetter == 'O' ||
                        firstLetter == 'U' || firstLetter == 'Y' || firstLetter == 'a' || firstLetter == 'e' ||
                        firstLetter == 'i' || firstLetter == 'o' || firstLetter == 'u' || firstLetter == 'y')
                {
                    sumOfWord *= length;
                }
                else
                    sumOfWord = Math.Floor(sumOfWord / length);

                if (sumOfWord > maxSum)
                {
                    maxSum = sumOfWord;
                    strongestWord = word;
                }

                sumOfWord = 0;
                word = Console.ReadLine();
            }
            Console.WriteLine($"The most powerful word is {strongestWord} - {maxSum}");
        }
    }
}
