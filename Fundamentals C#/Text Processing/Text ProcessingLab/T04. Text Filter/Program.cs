using System;

namespace T04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach(var banWord in bannedWords)
            {
                if (text.Contains(banWord))
                {
                    string replace = string.Empty;

                    while (replace.Length != banWord.Length)
                        replace += "*"; 

                    text = text.Replace(banWord, replace);

                    //text = text.Replace(banWord, new string('*', banword.Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}
