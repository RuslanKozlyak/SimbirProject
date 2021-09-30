using Domain.DTO.BookDtos;
using System.Collections.Generic;

namespace Domain.DTO.AuthorDtos
{
    public class AuthorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public List<BookWithGenreDto> Books { get; set; } = new List<BookWithGenreDto>();
    }
}
