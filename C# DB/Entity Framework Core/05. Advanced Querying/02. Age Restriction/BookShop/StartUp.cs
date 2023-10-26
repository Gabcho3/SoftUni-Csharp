namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string command = Console.ReadLine();
            string result = GetBooksByAgeRestriction(db, command);
            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var enumValue = Enum.Parse<AgeRestriction>(command, true);

            var bookTitles = context.Books
                .AsNoTracking()
                .Where(b => b.AgeRestriction == enumValue)
                .Select(b => b.Title)
                .OrderBy(t => t);

            return string.Join(Environment.NewLine, bookTitles);
        }
    }
}


