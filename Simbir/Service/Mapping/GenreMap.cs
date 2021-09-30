using AutoMapper;
using Domain.Data;
using Domain.DTO.GenreDtos;

namespace Service.Mapping
{
    public class GenreMap : Profile
    {
        public GenreMap()
        {
            CreateMap<GenreDto, Genre>();
            CreateMap<Genre, GenreDto>();

            CreateMap<GenreWithoutBooksDto, Genre>();
            CreateMap<Genre, GenreWithoutBooksDto>();

            CreateMap<GenreStatisticsDto, Genre>();
            CreateMap<Genre, GenreStatisticsDto>()
                .ForMember("Count", opt => opt.MapFrom(genre => genre.Books.Count));
        }
    }
}
