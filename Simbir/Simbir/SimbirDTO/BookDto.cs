using Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simbir.DTO
{
    public class BookDto 
    {
        /// <summary>
        /// Часть 2. п.2.2 Создание класса репрезентирующего книгу
        /// Часть 2.2 п.1 Добавление валицации, все поля NotNull
        /// </summary>
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }

        public static List<BookDto> BookList { get; set; }

        public static explicit operator Book(BookDto dto)
        {
            return new Book
            {
                Id = dto.Id,
                Title = dto.Title,
                AuthorId = dto.AuthorId
            };
        }

        public static implicit operator BookDto(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId
            };
        }
    }
}
