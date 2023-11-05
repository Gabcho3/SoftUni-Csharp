using System.Globalization;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using System.IO;
using _11._Import_Cars;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            ImportData(context);

            string result = GetLocalSuppliers(context);
            Console.WriteLine(result);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count,
                });

            return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
        }

        //Import Methods

        public static void ImportData(CarDealerContext context)
        {
            var suppliersInputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            ImportSuppliers(context, suppliersInputJson);

            var partsInputJson = File.ReadAllText(@"../../../Datasets/parts.json");
            ImportParts(context, partsInputJson);

            var carsInputJson = File.ReadAllText(@"../../../Datasets/cars.json");
            ImportCars(context, carsInputJson);

            var customersInputJson = File.ReadAllText(@"../../../Datasets/customers.json");
            ImportCustomers(context, customersInputJson);

            var salesInputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            ImportSales(context, salesInputJson);
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

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<List<CarDto>>(inputJson)!;

            foreach (var carDto in carsDto)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };
                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    };
                    context.PartsCars.Add(partCar);
                }
            }
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson)!;
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson)!;
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }
    }
}