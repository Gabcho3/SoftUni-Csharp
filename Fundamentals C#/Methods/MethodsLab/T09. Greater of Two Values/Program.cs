using System;

namespace T09._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch(type)
            {
                case "int":
                    int num1 = int.Parse(Console.ReadLine());
                    int num2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(num1, num2));
                    break;

                case "char":
                    char ch1 = char.Parse(Console.ReadLine());
                    char ch2 = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(ch1, ch2));
                    break;

                case "string":
                    string str1 = Console.ReadLine();
                    string str2 = Console.ReadLine();
                    Console.WriteLine(GetMax(str1, str2));
                    break;
            }
        }

        static int GetMax(int num1, int num2)
        {
            if(num1 > num2)
                return num1;
            else
                return num2;
        }

        static char GetMax(char ch1, char ch2)
        {
            if (ch1 > ch2)
                return ch1;
            else
                return ch2;
        }

        static string GetMax(string str1, string str2)
        {
            int result = str1.CompareTo(str2);

            if (result > 0)
                return str1;
            else
                return str2;
        }
    }
}
