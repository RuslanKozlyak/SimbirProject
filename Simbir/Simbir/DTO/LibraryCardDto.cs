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
        [Required]
        public HumanDto Human { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
    }
}
