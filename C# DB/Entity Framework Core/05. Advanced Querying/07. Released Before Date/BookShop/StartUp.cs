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

            string input = Console.ReadLine()!;
            string result = GetBooksReleasedBefore(db, input);
            Console.WriteLine(result);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string input)
        {
            DateTime date = DateTime.ParseExact(input, "dd-MM-yyyy", null);

            var booksReleasedBefore = context.Books
                .AsNoTracking()
                .Where(b => b.ReleaseDate < date)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in booksReleasedBefore)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


