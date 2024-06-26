﻿using System.Globalization;
using System.Text;
using AutoMapper;
using Footballers.Data.Models;
using Footballers.DataProcessor.ImportDto;
using Footballers.Utilities;
using Microsoft.Data.SqlClient.Server;
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
            var validCoaches = new HashSet<Coach>();

            StringBuilder sb = new StringBuilder();
            foreach (var coachDto in coachesDtos)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                int invalidFootballers = coachDto.Footballers.RemoveAll(f => !IsValid(f) ||
                                                                             DateTime.Parse(f.ContractStartDate) >
                                                                             DateTime.Parse(f.ContractEndDate));

                for (int i = 0; i < invalidFootballers; i++)
                {
                    sb.AppendLine(ErrorMessage);
                }

                Coach coach = AutoMapper.Map<Coach>(coachDto);
                validCoaches.Add(coach);

                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {

            return string.Empty;
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
