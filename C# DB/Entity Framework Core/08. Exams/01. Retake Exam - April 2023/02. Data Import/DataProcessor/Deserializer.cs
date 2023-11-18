using System.Text;
using AutoMapper;
using DataProcessor.ImportDto;
using Invoices.Data.Models;
using Invoices.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Invoices.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            IMapper mapper = InitializeAutoMapper();

            var clientDtos = xmlHelper.Deserialize<ImportClientsDto[]>(xmlString, "Clients");
            var validClients = new HashSet<Client>();

            StringBuilder sb = new StringBuilder();

            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var clientAddressDto = clientDto.Addresses[0];
                if (!IsValid(clientAddressDto) || string.IsNullOrEmpty(clientAddressDto.StreetName))
                {
                    sb.AppendLine("Invalid data!");
                    clientDto.Addresses = new List<ImportAddressesDto>();
                }

                var client = mapper.Map<Client>(clientDto);
                validClients.Add(client);
                sb.AppendLine($"Successfully imported client {client.Name}.");
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            IMapper mapper = InitializeAutoMapper();

            var invoiceDtos = JsonConvert.DeserializeObject<ImportInvoicesDto[]>(jsonString)!;
            var validInvoices = new HashSet<Invoice>();

            StringBuilder sb = new StringBuilder();
            foreach (var invoiceDto in invoiceDtos)
            {
                if (!IsValid(invoiceDto) || invoiceDto.DueDate < invoiceDto.IssueDate)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var invoice = mapper.Map<Invoice>(invoiceDto);
                validInvoices.Add(invoice);

                sb.AppendLine($"Successfully imported invoice with number {invoice.Number}.");
            }

            context.Invoices.AddRange(validInvoices);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            IMapper mapper = InitializeAutoMapper();

            var productsDto = JsonConvert.DeserializeObject<ImportProductsDto[]>(jsonString);
            var validProducts = new HashSet<Product>();
            var allClientsId = context.Clients.Select(c => c.Id);

            StringBuilder sb = new StringBuilder();
            foreach (var productDto in productsDto)
            {
                if (!IsValid(productDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var product = mapper.Map<Product>(productDto);
                foreach (var id in productDto.ClientsId.Distinct())
                {
                    if (!allClientsId.Contains(id))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var productClient = new ProductClient()
                    {
                        ClientId = id,
                        Product = product
                    };

                    product.ProductsClients.Add(productClient);
                }

                validProducts.Add(product);
                sb.AppendLine(
                    $"Successfully imported product - {product.Name} with {product.ProductsClients.Count} clients.");
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();
            return sb.ToString();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InvoicesProfile>();
            }));
    } 
}
