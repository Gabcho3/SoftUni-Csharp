using System;

namespace T01._Data_Type_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //HOW to CHECK data type of INPUT
            string input = Console.ReadLine();
            string finalType = string.Empty;

            while (input != "END")
                if (!string.IsNullOrEmpty(input))
                {
                    int tryInt;
                    double floatingPoint;
                    char character;
                    bool boolean;
                    string String;
                    if (Int32.TryParse(input, out tryInt))
                        finalType = "integer";
                    else if (Double.TryParse(input, out floatingPoint))
                        finalType = "floating point";
                    else if (Char.TryParse(input, out character))
                        finalType = "character";
                    else if (Boolean.TryParse(input, out boolean))
                        finalType = "boolean";
                    else
                        finalType = "string";
                    Console.WriteLine($"{input} is {finalType} type");
                    input = Console.ReadLine();
                }
        }
    }
}
