using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var readerWords = new StreamReader(wordsFilePath);
            var readerText = new StreamReader(textFilePath);
            var writer = new StreamWriter(outputFilePath);

            List<string> words = readerWords.ReadLine().Split().ToList();

            var wordsCounter = new Dictionary<string, int>();
            for (int i = 0; i < words.Count; i++)
            {
                wordsCounter.Add(words[i], 0);
            }
            using (readerText)
            {
                while (true)
                {
                    string text = readerText.ReadLine();

                    if (text == null)
                        break;

                    string[] array = text.Split('-', ' ', '?', '!', '.').Select(x => x.ToLower()).ToArray();

                    foreach (var word in array)
                    {
                        foreach (var w in words)
                        {
                            if (word == w)
                                wordsCounter[w]++;
                        }
                    }
                }
            }

            using (writer)
            {
                foreach (var (word, times) in wordsCounter)
                {
                    writer.WriteLine("{0} - {1}", word, times);
                }
            }
        }
    }
}