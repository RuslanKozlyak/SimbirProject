using AutoMapper;
using Domain.Data;
using Domain.DTO.BookDtos;

namespace Service.Mapping
{
    public class BookMap : Profile
    {
        public BookMap()
        {
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>();

            CreateMap<BookWithAuthorAndGenreDto, Book>();
            CreateMap<Book, BookWithAuthorAndGenreDto>();

            CreateMap<BookWithGenreDto, Book>();
            CreateMap<Book, BookWithGenreDto>();
        }
    }
}
