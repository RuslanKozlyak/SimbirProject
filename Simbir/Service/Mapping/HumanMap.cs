using AutoMapper;
using Domain.Data;
using Domain.DTO.HumanDtos;

namespace Service.Mapping
{
    public class HumanMap : Profile
    {
        public HumanMap()
        {
            CreateMap<HumanDto, Human>()
                .ForMember(dst => dst.Id, src => src.Ignore())
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.LastName))
                .ForMember(dst => dst.MiddleName, src => src.MapFrom(src => src.MiddleName))
                .ForMember(dst => dst.Books, src => src.MapFrom(src => src.Books))
                .ReverseMap()
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.LastName))
                .ForMember(dst => dst.MiddleName, src => src.MapFrom(src => src.MiddleName))
                .ForMember(dst => dst.Books, src => src.MapFrom(src => src.Books));

            CreateMap<HumanWithoutBooksDto, Human>()
                .ForMember(dst => dst.Id, src => src.Ignore())
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.LastName))
                .ForMember(dst => dst.MiddleName, src => src.MapFrom(src => src.MiddleName))
                .ForMember(dst => dst.Books, src => src.Ignore())
                .ReverseMap()
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.LastName))
                .ForMember(dst => dst.MiddleName, src => src.MapFrom(src => src.MiddleName));
        }
    }
}
