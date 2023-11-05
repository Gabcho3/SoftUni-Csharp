using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using System.IO;
using _11._Import_Cars;

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
            ImportParts(context, partsInputJson);

            var carsInputJson = File.ReadAllText(@"../../../Datasets/cars.json");
            Console.WriteLine(ImportCars(context, carsInputJson));
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
                    TravelledDistance = carDto.TraveledDistance
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
    }
}