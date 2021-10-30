using Domain.DTO.BookDtos;
using System.Collections.Generic;

namespace Domain.DTO.HumanDtos
{
    public class HumanWithBooksDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string? Birthday { get; set; }

        public List<BookWithAuthorAndGenreDto> Books { get; set; }
    }
}
