using AutoMapper;
using Web.Core.ViewModels;
using Web.Infrastructure.Models;

namespace Web.Core.AutoMapper
{
    public class BazarProfile : Profile
    {
        public BazarProfile()
        {
            //Ads
            CreateMap<Ad, AdViewModel>()
                .ForMember(dest => dest.Owner,
                    opt => opt.MapFrom(src => src.Owner))
                .ForMember(dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Ad, CreateAdViewModel>();

            CreateMap<CreateAdViewModel, Ad>();
        }
    }
}
