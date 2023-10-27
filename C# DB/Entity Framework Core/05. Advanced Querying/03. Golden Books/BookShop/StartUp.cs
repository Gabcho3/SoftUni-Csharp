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

            string result = GetGoldenBooks(db);
            Console.WriteLine(result);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var enumValue = Enum.Parse<EditionType>("Gold");

            var goldenBooks = context.Books
                .AsNoTracking()
                .Where(b => b.EditionType == enumValue && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            return string.Join(Environment.NewLine, goldenBooks);
        }
    }
}


