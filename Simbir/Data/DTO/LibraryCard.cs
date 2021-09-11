using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class LibraryCard 
    {
        /// <summary>
        /// Часть 2.1 п.1 Создание агрегатора репрезентирующего карточку в библиотеке
        /// Часть 2.2 п.1 Добавление валицации, все поля NotNull
        /// </summary>
        [Required]
        public int HumanId { get; set; }
        public Human Human { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
    }
}
