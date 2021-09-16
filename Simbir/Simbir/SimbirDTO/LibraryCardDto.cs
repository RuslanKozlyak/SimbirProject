using Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simbir.DTO
{
    public class LibraryCardDto
    {
        /// <summary>
        /// Часть 2.1 п.1 Создание агрегатора репрезентирующего карточку в библиотеке
        /// Часть 2.2 п.1 Добавление валицации, все поля NotNull
        /// </summary>
        /// 
        [Required]
        public int Id { get; set; }
        [Required]
        public int HumanId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }

        public static explicit operator LibraryCard(LibraryCardDto dto)
        {
            return new LibraryCard
            {
                Id = dto.Id,
                HumanId = dto.HumanId,
                BookId = dto.BookId
            };
        }

        public static implicit operator LibraryCardDto(LibraryCard lc)
        {
            return new LibraryCardDto
            {
                Id = lc.Id,
                HumanId = lc.HumanId,
                BookId = lc.BookId
            };
        }
    }
}
