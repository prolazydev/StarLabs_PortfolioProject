using AutoMapper;
using StarLabs_PortfolioProject.Areas.Admin.ViewModels;
using StarLabs_PortfolioProject.Models;

namespace StarLabs_PortfolioProject.Areas.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ChordViewModel, Chord>()
                .ForMember(dest => dest.Photo, opts => opts.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Photo, opts => opts.Ignore());
        }
    }
}
