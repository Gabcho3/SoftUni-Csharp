using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writer = new StreamWriter(outputFilePath);
            using (reader)
            {
                int num = 1;
                using (writer)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine($"{num++}. {line}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}