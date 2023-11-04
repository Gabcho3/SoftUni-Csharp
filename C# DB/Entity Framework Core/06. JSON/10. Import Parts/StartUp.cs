using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var suppliersInputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            ImportSuppliers(context, suppliersInputJson);

            var partsInputJson = File.ReadAllText(@"../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(context, partsInputJson));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson)!;
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var allSuppliersIds = context.Suppliers.Select(s => s.Id);

            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)!
                .Where(p => allSuppliersIds.Contains(p.SupplierId))
                .ToList();
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }
    }
}