namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"../../../Files/input.txt";
            string outputFilePath = @"../../../Files/output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writer = new StreamWriter(outputFilePath);

            using (reader)
            {
                using (writer)
                {
                    int line = 1;
                    while (true)
                    {
                        string textOnLine = reader.ReadLine();

                        int letters = 0;
                        int marks = 0;

                        if (textOnLine == null)
                            break;

                        foreach(var ch in textOnLine)
                        {
                            if (char.IsLetter(ch))
                                letters++;

                            if (char.IsPunctuation(ch))
                                marks++;
                        }

                        writer.WriteLine("Line {0}: {1} ({2}) ({3})", line++, textOnLine, letters, marks);
                    }
                }
            }
        }
    }

}