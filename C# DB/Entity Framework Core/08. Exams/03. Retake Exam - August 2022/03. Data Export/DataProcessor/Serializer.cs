using Newtonsoft.Json;
using Trucks.DataProcessor.ExportDto;
using Trucks.Utilities;

namespace Trucks.DataProcessor
{
    using AutoMapper;
    using Data;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchers = context.Despatchers
                .Where(d => d.Trucks.Count > 0)
                .Select(d => new ExportDespatcherDto()
                {
                    Name = d.Name,
                    TrucksCount = d.Trucks.Count,
                    Trucks = d.Trucks.Select(t => new ExportTruckDto()
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            Make = t.MakeType.ToString(),
                        })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToList()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.Name)
                .ToArray();

            return XmlHelper.Seserialize(despatchers, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks.Select(ct => ct.Truck)
                        .Where(t => t.TankCapacity >= capacity)
                        .ToArray()
                        .Select(t => new
                        {
                            TruckRegistrationNumber = t.RegistrationNumber,
                            VinNumber = t.VinNumber,
                            TankCapacity = t.TankCapacity,
                            CargoCapacity = t.CargoCapacity,
                            CategoryType = t.CategoryType.ToString(),
                            MakeType = t.MakeType.ToString()
                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }

        private static IMapper AutoMapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TrucksProfile>();
        }));
    }
}