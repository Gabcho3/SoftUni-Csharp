﻿using System.Globalization;
using Footballers.Data.Models;
using Footballers.DataProcessor.ImportDto;

namespace Footballers
{
    using AutoMapper;

    // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
    public class FootballersProfile : Profile
    {
        public FootballersProfile()
        {
            //Coaches
            CreateMap<ImportCoachesDto, Coach>();

            //Footballers
            CreateMap<ImportFootballersDto, Footballer>();

            //Teams
            CreateMap<ImportTeamDto, Team>();
        }
    }
}
