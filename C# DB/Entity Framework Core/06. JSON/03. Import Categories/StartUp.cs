using System;
using System.Text.Json;
using Newtonsoft.Json;
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

            string inputJsonUsers = File.ReadAllText(@"../../../Datasets/users.json");
            ImportUsers(context, inputJsonUsers);

            string inputJsonProducts = File.ReadAllText(@"../../../Datasets/products.json");
            ImportProducts(context, inputJsonProducts);

            string inputJsonCategories = File.ReadAllText(@"../../../Datasets/categories.json");
            string result = ImportCategories(context, inputJsonCategories);
            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User> usersToImport = JsonConvert.DeserializeObject<List<User>>(inputJson)!;
            context.Users.AddRange(usersToImport);
            context.SaveChanges();

            return $"Successfully imported {usersToImport.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> productsToImport = JsonConvert.DeserializeObject<List<Product>>(inputJson)!;
            context.Products.AddRange(productsToImport);
            context.SaveChanges();

            return $"Successfully imported {productsToImport.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            List<Category> categoriesToImport = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();
            context.Categories.AddRange(categoriesToImport);
            context.SaveChanges();

            return $"Successfully imported {categoriesToImport.Count}";
        }
    }
}