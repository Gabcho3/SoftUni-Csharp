using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            ImportData(context);

            string result = GetCategoriesByProductsCount(context);
            Console.WriteLine(result);
        }

        public static void ImportData(ProductShopContext context)
        {
            string inputJsonUsers = File.ReadAllText(@"../../../Datasets/users.json");
            string inputJsonProducts = File.ReadAllText(@"../../../Datasets/products.json");
            string inputJsonCategories = File.ReadAllText(@"../../../Datasets/categories.json");
            string inputJsonCategoriesProducts = File.ReadAllText(@"../../../Datasets/categories-products.json");

            List<User> usersToImport = JsonConvert.DeserializeObject<List<User>>(inputJsonUsers)!;
            context.Users.AddRange(usersToImport);
            context.SaveChanges();

            List<Product> productsToImport = JsonConvert.DeserializeObject<List<Product>>(inputJsonProducts)!;
            context.Products.AddRange(productsToImport);
            context.SaveChanges();

            List<Category> categoriesToImport = JsonConvert.DeserializeObject<List<Category>>(inputJsonCategories)
                .Where(c => c.Name != null)
                .ToList();
            context.Categories.AddRange(categoriesToImport);
            context.SaveChanges();


            List<CategoryProduct> categoryProductsToImport = JsonConvert
                .DeserializeObject<List<CategoryProduct>>(inputJsonCategoriesProducts)!;
            context.CategoriesProducts.AddRange(categoryProductsToImport);
            context.SaveChanges();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductCount = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = $"{c.CategoriesProducts.Average(cp => cp.Product.Price):f2}",
                    totalRevenue = $"{c.CategoriesProducts.Sum(cp => cp.Product.Price):f2}"
                });

            return JsonConvert.SerializeObject(categoriesByProductCount, Formatting.Indented);
        }
    }
}