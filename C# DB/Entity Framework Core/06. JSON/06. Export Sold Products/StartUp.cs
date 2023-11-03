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

            string result = GetSoldProducts(context);
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

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldItem = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price,
                            buyerFirstName = ps.Buyer.FirstName,
                            buyerLastName = ps.Buyer.LastName,
                        })
                });

            return JsonConvert.SerializeObject(usersWithSoldItem, Formatting.Indented);
        }
    }
}