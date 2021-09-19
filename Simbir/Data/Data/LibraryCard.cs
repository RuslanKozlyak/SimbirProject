using System;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Human Human { get; set; }
        public Book Book { get; set; }
    }
}
