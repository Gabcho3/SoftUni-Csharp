using AutoMapper;
using Homies.Core.DTOs;
using Homies.Infrastructure.Data.Models;

namespace Homies.Core.AutoMapper
{
    public class HomiesProfile : Profile
    {
        public HomiesProfile()
        {
            //Events
            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.Organiser,
                    opt => opt.MapFrom(src => src.Organiser.UserName))
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(src => src.Type.Name));

            CreateMap<CreateEventDto, Event>();
        }
    }
}
