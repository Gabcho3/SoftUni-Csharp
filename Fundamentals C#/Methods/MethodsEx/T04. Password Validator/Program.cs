using System;

namespace T04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isValid = false;
            CheckCharsLength(password, isValid);
        }

        static void CheckCharsLength(string password, bool isValid)
        {
            int passLength = password.Length;

            if (passLength < 6 || passLength > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            else
                isValid = true;

            CheckLettersAndDigits(password, isValid);
        }

        static void CheckLettersAndDigits(string password, bool isValid)
        {
            for(int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 'A' && password[i] <= 'Z')
                    isValid = true;

                else if (password[i] >= 'a' && password[i] <= 'z')
                    isValid = true;

                else if (password[i] >= '0' && password[i] <= '9')
                    isValid = true;
                else
                    isValid = false;

                if(!isValid)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    break;
                }
            }
            CheckNumberOfDigits(password, isValid);
        }

        static void CheckNumberOfDigits(string password, bool isValid)
        {
            int digitsCount = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= '0' && password[i] <= '9')
                    digitsCount++;
            }

            if(digitsCount < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            if(isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
