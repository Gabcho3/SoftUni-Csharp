using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var reader1 = new StreamReader(firstInputFilePath);
            var reader2 = new StreamReader(secondInputFilePath);
            var writer = new StreamWriter(outputFilePath);

            using(reader1)
            {
                using(reader2)
                {
                    using (writer)
                    {
                        while (!reader1.EndOfStream || !reader2.EndOfStream)
                        {
                            if (!reader1.EndOfStream)
                                writer.WriteLine(reader1.ReadLine());

                            if (!reader2.EndOfStream)
                                writer.WriteLine(reader2.ReadLine());
                        }
                    }
                }
            }
        }
    }
}

