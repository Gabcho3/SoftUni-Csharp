using System;

namespace T01._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch(type)
            {
                case "int":
                    int num = int.Parse(Console.ReadLine());
                    PrintResult(num);
                    break;
                case "real":
                    double realNum = double.Parse(Console.ReadLine());
                    PrintResult(realNum);
                    break;
                case "string":
                    string str = Console.ReadLine();
                    PrintResult(str);
                    break;
            }
        }

        static void PrintResult(int num)
        {
            Console.WriteLine(num * 2);
        }

        static void PrintResult(double realNum)
        {
            Console.WriteLine($"{realNum * 1.5:f2}");
        }

        static void PrintResult(string str)
        {
            Console.WriteLine($"${str}$");
        }
    }
}
