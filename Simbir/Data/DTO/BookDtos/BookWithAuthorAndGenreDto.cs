using Domain.DTO.AuthorDtos;
using Domain.DTO.GenreDtos;
using System;
using System.Collections.Generic;

namespace Domain.DTO.BookDtos
{
    public class BookWithAuthorAndGenreDto
    {
        public string Title { get; set; }
        public int? YearOfWriting { get; set; }
        public AuthorWithoutBooksDto Author { get; set; }
        public List<GenreWithoutBooksDto> Genres { get; set; }
    }
}
