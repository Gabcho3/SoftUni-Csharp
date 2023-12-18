using System.Globalization;
using Footballers.Data.Models;
using Footballers.DataProcessor.ExportDto;
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
            CreateMap<ImpoortFootballersDto, Footballer>();
            CreateMap<Footballer, ExportFootballerDto>()
                .ForMember(dest => dest.ContractStartDate, opt =>
                    opt.MapFrom(src => src.ContractStartDate.ToString("d", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.ContractEndDate, opt =>
                    opt.MapFrom(src => src.ContractEndDate.ToString("d", CultureInfo.InvariantCulture)));

            //Teams
            CreateMap<ImportTeamDto, Team>();
        }
    }
}
