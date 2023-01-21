namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            var reader = new FileStream(inputFilePath, FileMode.Open);
            var writer = new FileStream(outputFilePath, FileMode.Create);

            using (reader)
            {
                using (writer)
                {
                    while (true)
                    {
                        byte[] buffer = new byte[256];
                        int size = reader.Read(buffer, 0, buffer.Length);

                        if (size == 0)
                            break;

                        writer.Write(buffer, 0, size);
                    }
                }
            }
        }
    }
}