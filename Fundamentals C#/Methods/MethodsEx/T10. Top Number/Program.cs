using System;

namespace T10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            for(int num = 1; num <= number; num++)
            {
                IsDivisibleBy8(num);
            }
        }

        static void IsDivisibleBy8(int num)
        {
            int sumOfDigits = 0;
            bool isTop = false;

            int digits = num;

            while (digits > 0)
            {
                int currDigit = digits % 10;

                sumOfDigits += currDigit;

      		    digits = digits / 10;
            }

            if (sumOfDigits % 8 == 0)
                isTop = true;

            CheckOddDigts(num, isTop);
        }

        static void CheckOddDigts(int num, bool isTop)
        {
            int digits = num;
            int oddCount = 0;

            while (digits > 0)
            {
                int currDigit = digits % 10;

                if (currDigit % 2 != 0)
                    oddCount++;

                digits = digits / 10;
            }

            if (oddCount == 0)
                isTop = false;

            if (isTop)
                Console.WriteLine(num);
        }
    }
}
