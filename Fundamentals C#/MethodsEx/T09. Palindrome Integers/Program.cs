using System;

namespace T09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            while (number != "END")
            {
                ReturnNum(number);

                number = Console.ReadLine();
            }
        }

        static void ReturnNum(string number)
        {
            int[] num = new int[number.Length];

            for (int i = 0; i < num.Length; i++)
            {
                num[i] = int.Parse(number[i].ToString());
            }
            
            ReturnReverseNum(num, number);
        }

        static void ReturnReverseNum(int[] num, string number)
        {
            int[] reverseNum = new int[num.Length];

            for (int i = reverseNum.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < num.Length; j++)
                {
                    reverseNum[j] = num[i];
                    i--;
                }
            }

            CheckIfNumberIsPalindrome(num, reverseNum, number);
        }

        static void CheckIfNumberIsPalindrome(int[] num, int[] reverseNum, string number)
        {
            bool isPalindrome = false;

            for(int i = 0; i < reverseNum.Length; i++)
            {
                if (reverseNum[i] == num[i])
                    isPalindrome = true;

                else
                {
                    isPalindrome = false;
                    break;
                }
            }

            Console.WriteLine(isPalindrome ? "true" : "false");
        }
    }
}
