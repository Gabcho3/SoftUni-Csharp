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

            string result = GetUsersWithProducts(context);
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

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(p => p.Buyer != null),
                        products = u.ProductsSold.Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            })
                    }
                })
                .OrderByDescending(u => u.soldProducts.count);

            var output = new
            {
                usersCount = usersWithSoldProducts.Count(),
                users = usersWithSoldProducts
            };

            return JsonConvert.SerializeObject(output, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}