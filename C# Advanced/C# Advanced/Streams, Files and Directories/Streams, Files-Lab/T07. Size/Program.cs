using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double sum = 0;
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] infos = dir.GetFiles("*", SearchOption.AllDirectories);

            foreach(FileInfo info in infos )
            {
                sum += info.Length;
            }

            sum /= (1024) / 1024;
            File.WriteAllText(outputFilePath, sum.ToString());
        }
    }
}

