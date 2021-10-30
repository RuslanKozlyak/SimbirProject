using AutoMapper;
using Domain.Data;
using Domain.DTO.BookDtos;

namespace Service.Mapping
{
    public class BookMap : Profile
    {
        public BookMap()
        {
            CreateMap<BookDto, Book>()
                .ForMember(dst => dst.Id, src => src.Ignore())
                .ForMember(dst => dst.Title, src => src.MapFrom(src => src.Title))
                .ForMember(dst => dst.YearOfWriting, src => src.MapFrom(src => src.YearOfWriting))
                .ForMember(dst => dst.AuthorId, src => src.MapFrom(src => src.AuthorId))
                .ForMember(dst => dst.Author, src => src.MapFrom(src => src.Author))
                .ForMember(dst => dst.Genres, src => src.MapFrom(src => src.Genres))
                .ForMember(dst => dst.Humans, src => src.MapFrom(src => src.Humans))
                .ReverseMap()
                .ForMember(dst => dst.Title, src => src.MapFrom(src => src.Title))
                .ForMember(dst => dst.YearOfWriting, src => src.MapFrom(src => src.YearOfWriting))
                .ForMember(dst => dst.AuthorId, src => src.MapFrom(src => src.AuthorId))
                .ForMember(dst => dst.Author, src => src.MapFrom(src => src.Author))
                .ForMember(dst => dst.Genres, src => src.MapFrom(src => src.Genres))
                .ForMember(dst => dst.Humans, src => src.MapFrom(src => src.Humans));

            CreateMap<BookWithAuthorAndGenreDto, Book>()
                .ForMember(dst => dst.Id, src => src.Ignore())
                .ForMember(dst => dst.Title, src => src.MapFrom(src => src.Title))
                .ForMember(dst => dst.YearOfWriting, src => src.MapFrom(src => src.YearOfWriting))
                .ForMember(dst => dst.AuthorId, src => src.MapFrom(src => src.AuthorId))
                .ForMember(dst => dst.Author, src => src.MapFrom(src => src.Author))
                .ForMember(dst => dst.Genres, src => src.MapFrom(src => src.Genres))
                .ReverseMap()
                .ForMember(dst => dst.Title, src => src.MapFrom(src => src.Title))
                .ForMember(dst => dst.YearOfWriting, src => src.MapFrom(src => src.YearOfWriting))
                .ForMember(dst => dst.AuthorId, src => src.MapFrom(src => src.AuthorId))
                .ForMember(dst => dst.Author, src => src.MapFrom(src => src.Author))
                .ForMember(dst => dst.Genres, src => src.MapFrom(src => src.Genres));

            CreateMap<BookWithGenreDto, Book>()
                .ForMember(dst => dst.Id, src => src.Ignore())
                .ForMember(dst => dst.Title, src => src.MapFrom(src => src.Title))
                .ForMember(dst => dst.YearOfWriting, src => src.MapFrom(src => src.YearOfWriting))
                .ForMember(dst => dst.Genres, src => src.MapFrom(src => src.Genres))
                .ReverseMap()
                .ForMember(dst => dst.Title, src => src.MapFrom(src => src.Title))
                .ForMember(dst => dst.YearOfWriting, src => src.MapFrom(src => src.YearOfWriting))
                .ForMember(dst => dst.Genres, src => src.MapFrom(src => src.Genres));
        }
    }
}
