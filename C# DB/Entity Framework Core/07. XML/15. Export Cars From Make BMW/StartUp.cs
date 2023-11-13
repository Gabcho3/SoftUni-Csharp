using _02._Import_Products.Utilities;
using _09._Import_Suppliers.DTOs.Import;
using _10._Import_Parts.DTOs.Import;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using System.IO;
using System.Xml.Serialization;
using _11._Import_Cars.DTOs.Import;
using _12._Import_Customers.DTOs.Import;
using _13._Import_Sales.DTOs.Import;
using _14._Export_Cars_With_Distance.DTOs.Export;
using _15._Export_Cars_From_Make_BMW.DTOs.Export;
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

            ImportData(context);
            Console.WriteLine(GetCarsFromMakeBmw(context));
        }

        public static void ImportData(CarDealerContext context)
        {
            string suppliersInputXml = @"../../../Datasets/suppliers.xml";
            ImportSuppliers(context, suppliersInputXml);

            string partsInputXml = @"../../../Datasets/parts.xml";
            ImportParts(context, partsInputXml);

            string carsInputXml = @"../../../Datasets/cars.xml";
            ImportCars(context, carsInputXml);

            string customersInputXml = @"../../../Datasets/customers.xml";
            ImportCustomers(context, customersInputXml);

            string salesInputXml = @"../../../Datasets/sales.xml";
            ImportSales(context, salesInputXml);
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

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var carDtos = xmlHelper.Deserialize<ImportCarsDTO[]>(inputXml, "Cars");

            var validCars = new HashSet<Car>();
            foreach (var carDto in carDtos)
            {
                var car = mapper.Map<Car>(carDto);

                var partsCars = new HashSet<PartCar>();
                foreach (var partId in carDto.PartIds.Select(p => p.Id).Distinct())
                {
                    if (!context.Parts.Any(p => p.Id == partId))
                    {
                        continue;
                    }

                    partsCars.Add(new PartCar()
                    {
                        CarId = car.Id,
                        PartId = partId
                    });
                }

                car.PartsCars = partsCars;
                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        { 
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var customerDtos = xmlHelper.Deserialize<ImportCustomersDTO[]>(inputXml, "Customers");
            var customers = mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var saleDtos = xmlHelper.Deserialize<ImportSalesDTO[]>(inputXml, "Sales");

            var validSales = new HashSet<Sale>();
            foreach (var saleDto in saleDtos)
            {
                if (!context.Cars.Any(c => c.Id == saleDto.CarId))
                {
                    continue;
                }

                var sale = mapper.Map<Sale>(saleDto);
                validSales.Add(sale);
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => mapper.Map<ExportSpecificCarsMake>(c))
                .ToArray();

            return xmlHelper.Serialize(cars, "cars");
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}