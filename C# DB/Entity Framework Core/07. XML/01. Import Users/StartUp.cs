using System.Xml.Linq;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var inputUsersXml = @"../../../Datasets/users.xml";
            Console.WriteLine(ImportUsers(context, inputUsersXml));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XDocument xDocument = XDocument.Load(inputXml);

            var usersElements = xDocument.Root!.Elements("User");

            var usersToImport = new List<User>();
            foreach (var userElement in usersElements)
            {
                var userDto = new User()
                {
                    FirstName = userElement.Element("firstName")!.Value,
                    LastName = userElement.Element("lastName")!.Value,
                    Age = int.Parse(userElement.Element("age")!.Value)
                };
                usersToImport.Add(userDto);
            }

            context.Users.AddRange(usersToImport);
            context.SaveChanges();

            return $"Successfully imported {usersToImport.Count}";
        }
    }
}