using AutoMapper;
using Domain.Data;
using Domain.DTO.AuthorDtos;

namespace Service.Mapping
{
    public class AuthorMap : Profile
    {
        public AuthorMap()
        {
            CreateMap<AuthorDto, Author>();
            CreateMap<Author, AuthorDto>();

            CreateMap<AuthorWithoutBooksDto, Author>();
            CreateMap<Author, AuthorWithoutBooksDto>();

            CreateMap<AuthorWithBooksDto, Author>();
            CreateMap<Author, AuthorWithBooksDto>();
        }
    }
}
