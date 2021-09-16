using Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simbir.DTO
{
    public class HumanDto
    {
        /// <summary>
        /// Часть 2. п.2.1 Создание класса репрезентирующего человека
        /// Часть 2.2 п.1 Добавление валицации, все поля NotNull
        /// </summary>
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string? Birthday { get; set; }

        public List<BookDto> Books { get; set; }

        public static explicit operator Human(HumanDto dto)
        {
            return new Human
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MiddleName = dto.MiddleName,
                Birthday = dto.Birthday
            };
        }

        public static implicit operator HumanDto(Human human)
        {
            return new HumanDto
            {
                Id = human.Id,
                FirstName = human.FirstName,
                LastName = human.LastName,
                MiddleName = human.MiddleName,
                Birthday = human.Birthday
            };
        }

        public static explicit operator Author(HumanDto dto)
        {
            return new Author
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MiddleName = dto.MiddleName,
            };
        }

        public static implicit operator HumanDto(Author human)
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
