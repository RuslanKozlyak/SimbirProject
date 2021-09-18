using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DTO
{
    /// <summary>
    /// Часть 2 п 2 Подготовить в приложении сущности согласно созданной ранее базе данных. 
    /// </summary>
    [Table("library_card")]
    public class LibraryCard : BaseEntity
    {
        [Column("person_id")]
        public int HumanId { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("pickup_date")]
        public DateTime Date { get; set; }

        [NotMapped]
        public Human Human { get; set; }
        [NotMapped]
        public Book Book { get; set; }
    }
}
