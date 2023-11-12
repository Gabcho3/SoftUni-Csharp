using _02._Import_Products.Utilities;
using _09._Import_Suppliers.DTOs.Import;
using _10._Import_Parts.DTOs.Import;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using System.IO;
using Newtonsoft;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string suppliersInputXml = @"../../../Datasets/suppliers.xml";
            ImportSuppliers(context, suppliersInputXml);

            string partsInputXml = @"../../../Datasets/parts.xml";
            Console.WriteLine(ImportParts(context, partsInputXml));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();
            
            var supplierDtos = xmlHelper.Deserialize<ImportSuppliersDTO[]>(inputXml, "Suppliers");

            var validSuppliers = new HashSet<Supplier>();
            foreach (var supplierDto in supplierDtos)
            {
                if (string.IsNullOrEmpty(supplierDto.Name))
                {
                    continue;
                }

                var supplier = mapper.Map<Supplier>(supplierDto);
                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var partDtos = xmlHelper.Deserialize<ImportPartsDTO[]>(inputXml, "Parts");

            var validParts = new HashSet<Part>();
            foreach (var partDto in partDtos)
            {
                int? supplierId = partDto.SupplierId;
                if (string.IsNullOrEmpty(partDto.Name) || supplierId == null 
                    || !context.Suppliers.Any(s => s.Id == supplierId))
                {
                    continue;
                }

                var part = mapper.Map<Part>(partDto);
                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}