using System;

namespace T01.OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bookNeeded = Console.ReadLine();
            string nextBook = Console.ReadLine();
            int bookCheck = 0;
            bool bookFound = false;
            while(nextBook != "No More Books")
            {
                bookFound = false;
                if(nextBook == bookNeeded)
                {
                    bookFound = true;
                    break;
                }
                bookCheck++;
                nextBook = Console.ReadLine();
            }
            if (bookFound)
            {
                Console.WriteLine($"You checked {bookCheck} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {bookCheck} books.");
            }
            
        }
    }
}
