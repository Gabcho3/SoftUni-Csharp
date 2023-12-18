using System.Globalization;
using AutoMapper;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ExportDto;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using Data;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            throw new NotImplementedException();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teamsWithMostPlayers = context.Teams
                .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .ToArray()
                .OrderByDescending(t => t.TeamsFootballers.Count)
                .ThenBy(t => t.Name)
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers.Select(tf => tf.Footballer).ToArray()
                        .Select(f => new ExportFootballerDto()
                        {
                            FootballerName = f.Name,
                            ContractStartDate = f.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = f.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = f.BestSkill.ToString(),
                            PositionType = f.Position.ToString(),
                        })
                        .OrderByDescending(f => f.ContractEndDate)
                        .ThenBy(f => f.FootballerName)
                        .ToArray()
                })
                .Take(5);

            return JsonConvert.SerializeObject(teamsWithMostPlayers, Formatting.Indented);
        }

        private static IMapper AutoMapper
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
            }));
    }
}
