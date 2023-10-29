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

            IncreasePrices(db);
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksBeforeYear = context.Books
                .Where(b => b.ReleaseDate!.Value.Year < 2010);

            foreach (var book in booksBeforeYear)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
    }
}


