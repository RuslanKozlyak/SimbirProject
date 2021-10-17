using AutoMapper;
using Domain.Data;
using Domain.DTO.AuthorDtos;

namespace Service.Mapping
{
    public class AuthorMap : Profile
    {
        public AuthorMap()
        {
            CreateMap<AuthorDto, Author>()
                .ForMember(dst => dst.Id, src => src.Ignore()).ReverseMap()
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.LastName))
                .ForMember(dst => dst.MiddleName, src => src.MapFrom(src => src.MiddleName))
                .ForMember(dst => dst.Books, src => src.MapFrom(src => src.Books))
                .ReverseMap()
                .ForMember(dst => dst.Id, src => src.Ignore())
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.LastName))
                .ForMember(dst => dst.MiddleName, src => src.MapFrom(src => src.MiddleName))
                .ForMember(dst => dst.Books, src => src.MapFrom(src => src.Books));

            CreateMap<AuthorWithoutBooksDto, Author>()
                .ForMember(dst => dst.Id, src => src.Ignore())
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.LastName))
                .ForMember(dst => dst.MiddleName, src => src.MapFrom(src => src.MiddleName))
                .ForMember(dst => dst.Books, src => src.Ignore())
                .ReverseMap()
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.LastName))
                .ForMember(dst => dst.MiddleName, src => src.MapFrom(src => src.MiddleName));

            CreateMap<AuthorWithBooksDto, Author>()
                .ForMember(dst => dst.Id, src => src.Ignore())
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.LastName))
                .ForMember(dst => dst.MiddleName, src => src.MapFrom(src => src.MiddleName))
                .ForMember(dst => dst.Books, src => src.Ignore())
                .ReverseMap()
                .ForMember(dst => dst.FirstName, src => src.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(src => src.LastName))
                .ForMember(dst => dst.MiddleName, src => src.MapFrom(src => src.MiddleName))
                .ForMember(dst => dst.Books, src => src.MapFrom(src => src.Books));
        }
    }
}
