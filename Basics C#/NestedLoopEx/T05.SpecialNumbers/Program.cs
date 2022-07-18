using System;

namespace T05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            bool isSpecial = false;
            for (int num = 1111; num <= 9999; num++)
            {
                string everyNum = num.ToString();
                for (int i = 0; i < everyNum.Length; i++)
                {
                    int number = int.Parse(everyNum[i].ToString());
                    if(number == 0)
                    {
                        isSpecial = false;
                        break;
                    }
                    else if (N % number == 0)
                    {
                        isSpecial = true;

                    }
                    else
                    {
                        isSpecial = false;
                        break;
                    }
                }
                if (isSpecial)
                {
                    Console.Write(num + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
