using System;
using System.Text.Json;
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
            string result = GetProductsInRange(context);
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

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsBetween500And1000 = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = p.Seller.FirstName + ' ' + p.Seller.LastName,
                });


            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var exportedSerializeObject =
                JsonConvert.SerializeObject(productsBetween500And1000, new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });

            return exportedSerializeObject;
        }
    }
}