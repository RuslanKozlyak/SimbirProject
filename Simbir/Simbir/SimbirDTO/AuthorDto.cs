using Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simbir.DTO
{
    public class AuthorDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public static explicit operator Author(AuthorDto dto)
        {
            return new Author
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MiddleName = dto.MiddleName,
            };
        }

        public static implicit operator AuthorDto(Author human)
        {
            return new Author
            {
                Id = human.Id,
                FirstName = human.FirstName,
                LastName = human.LastName,
                MiddleName = human.MiddleName,
            };
        }
    }
}
