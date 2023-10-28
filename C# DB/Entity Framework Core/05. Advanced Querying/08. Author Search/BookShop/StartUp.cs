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
            string result = GetAuthorNamesEndingIn(db, input);
            Console.WriteLine(result);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string endsIn)
        {
            var authorsFullNamesEndIn = context.Authors
                .Where(a => a.FirstName.EndsWith(endsIn))
                .Select(a => a.FirstName + ' ' + a.LastName)
                .OrderBy(n => n);

            return string.Join(Environment.NewLine, authorsFullNamesEndIn);
        }
    }
}


