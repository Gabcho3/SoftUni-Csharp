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

            string result = GetBooksByPrice(db);
            Console.WriteLine(result);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var goldenBooks = context.Books
                .AsNoTracking()
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price,
                })
                .OrderByDescending(b => b.Price);

            StringBuilder sb = new StringBuilder();

            foreach (var book in goldenBooks)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


