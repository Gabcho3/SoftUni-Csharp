using System.Globalization;
using System.Text;
using AutoMapper;
using Footballers.Data.Models;
using Footballers.DataProcessor.ImportDto;
using Footballers.Utilities;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var coachesDtos = XmlHelper.Deserialize<ImportCoachesDto[]>(xmlString, "Coaches");
            var validCoachesWithFootballers = new HashSet<Coach>();

            StringBuilder sb  = new StringBuilder();
            foreach (var coachDto in coachesDtos)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                int invalidFootballers = coachDto.Footballers
                    .RemoveAll(dto => !IsValid(dto) || DateTime.Parse(dto.ContractEndDate) < DateTime.Parse(dto.ContractStartDate));
                for (int i = 0; i < invalidFootballers; i++)
                {
                    sb.AppendLine("Invalid data!");
                }

                Coach coach = AutoMapper.Map<Coach>(coachDto);
                validCoachesWithFootballers.Add(coach);

                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(validCoachesWithFootballers);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var teamsDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);
            var allFotballersIds = context.Footballers.Select(f => f.Id);

            var validTeamWithFootballers = new HashSet<Team>();
            StringBuilder sb = new StringBuilder();

            foreach (var teamDto in teamsDtos)
            {
                if (!IsValid(teamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = AutoMapper.Map<Team>(teamDto);

                foreach (var id in teamDto.FootballersIds)
                {
                    if (!allFotballersIds.Contains(id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer()
                    {
                        FootballerId = id,
                        Team = team
                    });
                }

                validTeamWithFootballers.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(validTeamWithFootballers);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static IMapper AutoMapper
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
            }));
    }
}
