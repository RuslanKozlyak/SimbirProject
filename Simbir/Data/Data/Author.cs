using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DTO
{
    /// <summary>
    /// Часть 2 п 2 Подготовить в приложении сущности согласно созданной ранее базе данных. 
    /// </summary>
    [Table("author")]
    public class Author : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("middle_name")]
        public string MiddleName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
