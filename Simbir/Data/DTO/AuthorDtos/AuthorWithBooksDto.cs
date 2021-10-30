using Domain.DTO.BookDtos;
using System.Collections.Generic;

namespace Domain.DTO.AuthorDtos
{
    public class AuthorWithBooksDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public List<BookWithAuthorAndGenreDto> Books { get; set; } = new List<BookWithAuthorAndGenreDto>();
    }
}
