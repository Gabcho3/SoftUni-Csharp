namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ValueGeneration;
    using System.Diagnostics;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string result = GetMostRecentBooks(db);
            Console.WriteLine(result);
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var recentBooksByCategory = context.Categories
                .AsNoTracking()
                .Select(c => new
                {
                    CategoryName = c.Name,
                    RecentBooks = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Select(cb => new
                        {
                            BookTitle = cb.Book.Title,
                            ReleaseYear = cb.Book.ReleaseDate!.Value.Year
                        })
                        .Take(3)
                })
                .OrderBy(c => c.CategoryName);

            StringBuilder sb = new StringBuilder();
            foreach(var category in recentBooksByCategory)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach(var book in category.RecentBooks)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}


