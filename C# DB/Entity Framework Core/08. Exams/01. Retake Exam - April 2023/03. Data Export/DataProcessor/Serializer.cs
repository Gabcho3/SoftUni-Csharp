using System.Globalization;
using Invoices.DataProcessor.ExportDto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Invoices.DataProcessor
{
    using AutoMapper;
    using Invoices.Data;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var clients = context.Clients
                .Where(c => c.Invoices.Count > 0)
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .Select(c => new ExportClientsDto()
                {
                    InvoicesCount = c.Invoices.Count,
                    Name = c.Name,
                    VatNumber = c.NumberVat,
                    Invoices = c.Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(i => new ExportInvoicesDto()
                        {
                            Number = i.Number,
                            Amount = i.Amount,
                            DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            CurrencyType = i.CurrencyType.ToString()
                        })
                        .ToList()
                })
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(c => c.Name)
                .ToArray();

            return xmlHelper.Serialize(clients, "Clients");
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            IMapper mapper = InitializeAutoMapper();

            var products = context.Products
                .AsNoTracking()
                .Where(p => p.ProductsClients.Count > 0)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(pc => new
                        {
                            Name = pc.Client.Name,
                            NumberVat = pc.Client.NumberVat,
                        })
                        .OrderBy(c => c.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InvoicesProfile>();
            }));
    }
}