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

            string result = GetTotalProfitByCategory(db);
            Console.WriteLine(result);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var totalProfitOfCategories = context.BooksCategories
                .GroupBy(bc => bc.Category.Name)
                .Select(bc => new
                {
                    CategoryName = bc.Key,
                    TotalProfit = bc.Sum(bc => bc.Book.Price * bc.Book.Copies)
                })
                .OrderByDescending(bc => bc.TotalProfit)
                .ThenBy(bc => bc.CategoryName);

            StringBuilder sb = new StringBuilder();
            foreach (var category in totalProfitOfCategories)
            {
                sb.AppendLine($"{category.CategoryName} ${category.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


