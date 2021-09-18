using Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simbir.DTO
{
    public class GenreDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string GenreName { get; set; }

        public static explicit operator Genre(GenreDto dto)
        {
            return new Genre
            {
                Id = dto.Id,
                GenreName = dto.GenreName
            };
        }

        public static implicit operator GenreDto(Genre book)
        {
            return new GenreDto
            {
                Id = book.Id,
                GenreName = book.GenreName
            };
        }
    }
}
