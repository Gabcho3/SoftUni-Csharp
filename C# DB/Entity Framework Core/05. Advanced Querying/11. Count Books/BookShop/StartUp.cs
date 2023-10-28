namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            int input = int.Parse(Console.ReadLine());
            int result = CountBooks(db, input);
            Console.WriteLine(result);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int booksWithLongerTitle = context.Books
                .Count(b => b.Title.Length > lengthCheck);

            return booksWithLongerTitle;
        }
    }
}


