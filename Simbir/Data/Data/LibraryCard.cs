using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DTO
{
    [Table("library_card")]
    public class LibraryCard : BaseEntity
    {
        /// <summary>
        /// Часть 2.1 п.1 Создание агрегатора репрезентирующего карточку в библиотеке
        /// Часть 2.2 п.1 Добавление валицации, все поля NotNull
        /// </summary>
        [Column("person_id")]
        public int HumanId { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("pickup_date")]
        public DateTimeOffset Date { get; set; }

        [NotMapped]
        public Human Human { get; set; }
        [NotMapped]
        public Book Book { get; set; }
    }
}
