using Domain.DTO.GenreDtos;
using System;
using System.Collections.Generic;

namespace Domain.DTO.BookDtos
{
    public class BookWithGenreDto
    {
        public string Title { get; set; }
        public DateTime? YearOfWriting { get; set; }
        public List<GenreWithoutBooksDto> Genres { get; set; } = new List<GenreWithoutBooksDto>();
    }
}
