using System;
using System.Linq;

namespace T05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNum = Console.ReadLine();
            int smallNum = int.Parse(Console.ReadLine());

            if(smallNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            string result = string.Empty;

            int firstDigit = 0; //firstDigit of multiply

            //Queue multiplication
            for (int i = bigNum.Length - 1; i >= 0; i--)
            {
                int num = int.Parse(bigNum[i].ToString());

                int multiply = num * smallNum + firstDigit; //multyply plus previous firstDigit

                if (i == 0)
                {
                    string lastNum = multiply.ToString();

                    if (lastNum.Length > 1)
                        lastNum = lastNum[1].ToString() + lastNum[0].ToString(); //reversing lastNum

                    result += lastNum;
                }

                else
                    result += multiply % 10; //geting secondDigit of multyply

                firstDigit = multiply / 10;

            }

            //Reversing result
            for(int i = result.Length - 1; i >= 0; i--)
                Console.Write(result[i]);
        }
    }
}
