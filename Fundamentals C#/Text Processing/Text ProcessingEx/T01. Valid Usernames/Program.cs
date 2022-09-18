using System;

namespace T01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            foreach(string username in usernames)
            {
                bool isValid = false;

                if (username.Length >= 3 && username.Length <= 16)
                {
                    foreach(char ch in username)
                    {
                        if (char.IsLetter(ch) || char.IsDigit(ch) || ch == '-' || ch == '_')
                            isValid = true;

                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                if (isValid)
                    Console.WriteLine(username);
            }
        }
    }
}
