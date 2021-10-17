using Domain.DTO.BookDtos;
using System.Collections.Generic;

namespace Domain.DTO.GenreDtos
{
    public class GenreDto
    {
        public string GenreName { get; set; }
        public List<BookDto> Books { get; set; }
    }
}
