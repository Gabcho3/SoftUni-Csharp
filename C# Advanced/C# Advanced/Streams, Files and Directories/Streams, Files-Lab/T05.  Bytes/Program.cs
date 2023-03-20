using System;
using System.IO;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using(FileStream binary = new FileStream(binaryFilePath, FileMode.Open))
            {
                using (FileStream bytes = new FileStream(bytesFilePath, FileMode.Open))
                {
                    byte[] binaryBuffer = new byte[binary.Length];
                    byte[] bytesBuffer = new byte[bytes.Length];

                    binary.Read(binaryBuffer, 0, binaryBuffer.Length);
                    bytes.Read(bytesBuffer, 0, bytesBuffer.Length);

                    using(FileStream output = new FileStream(outputPath, FileMode.Create))
                    {
                        for(int i = 0; i < binaryBuffer.Length; i++)
                        {
                            for(int j = 0; j < bytesBuffer.Length; j++)
                            {
                                if (binaryBuffer[i] == bytesBuffer[j])
                                    output.Write(new byte[] { binaryBuffer[i] });
                            }
                        }
                    }
                }
            }
        }
    }
}
