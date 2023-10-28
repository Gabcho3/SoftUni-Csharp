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
            string result = GetBooksByAuthor(db, input);
            Console.WriteLine(result);
        }

        public static string GetBooksByAuthor(BookShopContext context, string startsWith)
        {
            var booksAndAuthors = context.Books
                .AsNoTracking()
                .Where(b => b.Author.LastName.ToLower().StartsWith(startsWith.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Title = b.Title,
                    AuthorFullName = b.Author.FirstName + ' ' + b.Author.LastName
                });

            StringBuilder sb = new StringBuilder();
            foreach(var book in booksAndAuthors)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


