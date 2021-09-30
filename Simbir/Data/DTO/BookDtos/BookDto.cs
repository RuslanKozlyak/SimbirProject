using Domain.DTO.AuthorDtos;
using Domain.DTO.GenreDtos;
using Domain.DTO.HumanDtos;
using System;
using System.Collections.Generic;

namespace Domain.DTO.BookDtos
{
    public class BookDto
    {
        /// <summary>
        /// Часть 2. п.2.2 Создание класса репрезентирующего книгу
        /// Часть 2.2 п.1 Добавление валицации, все поля NotNull
        /// </summary>
        /// 
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public DateTime? YearOfWriting { get; set; }

        public AuthorWithoutBooksDto Author { get; set; }
        public List<GenreDto> Genres { get; set; }
        public List<HumanDto> Humans { get; set; }
    }
}
