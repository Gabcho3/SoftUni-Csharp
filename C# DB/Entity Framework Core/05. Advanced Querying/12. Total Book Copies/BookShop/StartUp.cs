namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ValueGeneration;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string result = CountCopiesByAuthor(db);
            Console.WriteLine(result);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var totalCopiesBuAuthor = context.Authors
                .Select(a => new
                {
                    AuthorFullName = a.FirstName + ' ' + a.LastName,
                    TotalBookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalBookCopies);

            StringBuilder sb = new StringBuilder();
            foreach (var author in totalCopiesBuAuthor)
            {
                sb.AppendLine($"{author.AuthorFullName} - {author.TotalBookCopies}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


