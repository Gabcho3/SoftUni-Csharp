using System;

namespace T02._English_Name_of_the_Last_Digit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var integer = int.Parse(Console.ReadLine());
            var num = integer.ToString();
            var lastDigit = 0;
            var value = "";
            for(int i = 0; i < num.Length; i++)
            {
                lastDigit = int.Parse(num[i].ToString());
            }
            switch(lastDigit)
            {
                case 0: value = "zero"; break;
                case 1: value = "one"; break;
                case 2: value = "two"; break;
                case 3: value = "three"; break;
                case 4: value = "four"; break;
                case 5: value = "five"; break;
                case 6: value = "six"; break;
                case 7: value = "seven"; break;
                case 8: value = "eight"; break;
                case 9: value = "nine"; break;
            }
            Console.WriteLine(value);
        }
    }
}
