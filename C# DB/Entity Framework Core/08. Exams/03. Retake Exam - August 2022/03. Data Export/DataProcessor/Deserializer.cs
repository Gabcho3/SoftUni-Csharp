using System.Text;
using AutoMapper;
using Newtonsoft.Json;
using Trucks.Data.Models;
using Trucks.DataProcessor.ImportDto;
using Trucks.Utilities;

namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Data;


    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var despathersDtos = XmlHelper.Deserialize<ImportDespatcherDto[]>(xmlString, "Despatchers");
            var validDespatchersWithTrucks = new HashSet<Despatcher>();

            StringBuilder sb = new StringBuilder();
            foreach (var despatcherDto in despathersDtos)
            {
                if (!IsValid(despatcherDto) || string.IsNullOrEmpty(despatcherDto.Position))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                int invalidTrucks = despatcherDto.Trucks
                    .RemoveAll(t => !IsValid(t) 
                                    || string.IsNullOrEmpty(t.VinNumber) 
                                    || string.IsNullOrEmpty(t.RegistrationNumber));

                for (int i = 0; i < invalidTrucks; i++)
                {
                    sb.AppendLine("Invalid data!");
                }

                var depatcher = AutoMapper.Map<Despatcher>(despatcherDto);
                validDespatchersWithTrucks.Add(depatcher);

                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, depatcher.Name, depatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(validDespatchersWithTrucks);
            context.SaveChanges();

            return sb.ToString();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var clientsDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);
            var allTrucksId = context.Trucks.Select(t => t.Id).ToList();

            var validClientsWithTrucks = new HashSet<Client>();

            StringBuilder sb = new StringBuilder();
            foreach (var clientDto in clientsDtos)
            {
                if (!IsValid(clientDto) || string.IsNullOrEmpty(clientDto.Nationality) || clientDto.Type == "usual")
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Client client = AutoMapper.Map<Client>(clientDto);

                foreach (var id in clientDto.TrucksIds)
                {
                    if (!allTrucksId.Contains(id))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    client.ClientsTrucks.Add(new ClientTruck()
                    {
                        Client = client,
                        TruckId = id
                    });
                }

                validClientsWithTrucks.Add(client);

                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.Clients.AddRange(validClientsWithTrucks);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static IMapper AutoMapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TrucksProfile>();
        }));
    }
}