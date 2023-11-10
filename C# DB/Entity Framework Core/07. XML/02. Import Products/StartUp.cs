using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using _02._Import_Products.DTOs.Import;
using _02._Import_Products.Utilities;
using AutoMapper;
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
            ImportUsers(context, inputUsersXml);

            var inputProductsXml = @"../../../Datasets/products.xml";
            Console.WriteLine(ImportProducts(context, inputProductsXml));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportUserDTO[] usersDtos = xmlHelper.Deserialize<ImportUserDTO[]>(inputXml, "Users");
            ICollection<User>usersToAdd = new HashSet<User>();

            foreach (var userDto in usersDtos)
            {
                User user = mapper.Map<User>(userDto);
                usersToAdd.Add(user);
            }

            context.Users.AddRange(usersToAdd);
            context.SaveChanges();

            return $"Successfully imported {usersToAdd.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportProductDTO[] productDtos = xmlHelper.Deserialize<ImportProductDTO[]>(inputXml, "Products");
            ICollection<Product> validProducts = new HashSet<Product>();

            foreach (var productDto in productDtos)
            {
                Product product = mapper.Map<Product>(productDto);

                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
    }
}