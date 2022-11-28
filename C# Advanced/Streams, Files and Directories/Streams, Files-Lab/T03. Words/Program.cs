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
            var counter = new Dictionary<string, int>(); //word, counter
            List<string> words = new List<string>();
            List<string> texts = new List<string>();

            var readerOfWord = new StreamReader(wordsFilePath);
            var readerOfText = new StreamReader(textFilePath);
            var writer = new StreamWriter(outputFilePath);

            string[] lineInWords = readerOfWord.ReadLine().Split();
            using (readerOfWord)
            {
                for (int i = 0; i < lineInWords.Length; i++)
                {
                    words.Add(lineInWords[i]);
                }
            }

            using (readerOfText)
            {
                while (!readerOfText.EndOfStream)
                {
                    string[] lineInTexts = readerOfText.ReadLine().Split(',', ' ', '-', '?', '!', '.').Select(x => x.ToLower()).ToArray();

                    foreach (var word in lineInTexts)
                        texts.Add(word);

                }
            }

            foreach(var word in words)
            {
                foreach(var txt in texts)
                {
                    if(word.ToLower() == txt.ToLower())
                    {
                        if (!counter.ContainsKey(word))
                            counter.Add(word, 0);

                        counter[word]++;
                    }
                }
            }

            counter = counter.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            using (writer)
            {
                foreach (var (word, count) in counter)
                    writer.WriteLine($"{word} - {count}");
            }
        }
    }
}

