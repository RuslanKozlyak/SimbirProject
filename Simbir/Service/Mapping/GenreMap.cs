using AutoMapper;
using Domain.Data;
using Domain.DTO.GenreDtos;

namespace Service.Mapping
{
    public class GenreMap : Profile
    {
        public GenreMap()
        {
            CreateMap<GenreDto, Genre>()
                .ForMember(dst => dst.Id, src => src.Ignore())
                .ForMember(dst => dst.GenreName, src => src.MapFrom(src => src.GenreName))
                .ForMember(dst => dst.Books, src => src.MapFrom(src => src.Books))
                .ReverseMap()
                .ForMember(dst => dst.GenreName, src => src.MapFrom(src => src.GenreName))
                .ForMember(dst => dst.Books, src => src.MapFrom(src => src.Books));

            CreateMap<GenreWithoutBooksDto, Genre>().ForMember(dst => dst.Id, src => src.Ignore())
                .ForMember(dst => dst.GenreName, src => src.MapFrom(src => src.GenreName))
                .ForMember(dst => dst.Books, src => src.Ignore())
                .ReverseMap()
                .ForMember(dst => dst.GenreName, src => src.MapFrom(src => src.GenreName));

            CreateMap<GenreStatisticsDto, Genre>()
                .ForMember(dst => dst.Id, src => src.Ignore())
                .ForMember(dst => dst.GenreName, src => src.MapFrom(src => src.GenreName))
                .ForMember(dst => dst.Books, src => src.Ignore())
                .ReverseMap()
                .ForMember(dst => dst.Count, src => src.MapFrom(src => src.Books.Count));
        }
    }
}
