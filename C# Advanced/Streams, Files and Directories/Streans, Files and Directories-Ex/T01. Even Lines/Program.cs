namespace EvenLines
{
    using System;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            string output = string.Empty;

            using(reader)
            {
                int line = 0;
                while(true)
                {
                    string lineText = reader.ReadLine();
                    if (lineText == null)
                        break;

                    if(line % 2 == 0)
                    {
                        lineText = lineText.Replace('-', '@');
                        lineText = lineText.Replace(',', '@');
                        lineText = lineText.Replace('.', '@');
                        lineText = lineText.Replace('!', '@');
                        lineText = lineText.Replace('?', '@');

                        Stack<string> stack = new Stack<string>(lineText.Split().ToArray());

                        while (stack.Count > 0)
                        {
                            output += stack.Pop() + " ";
                        }
                        output += "\n";
                    }
                    line++;
                }
            }

            return output;
        }
    }
}