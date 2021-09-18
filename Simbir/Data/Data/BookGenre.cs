
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO 
{
    /// <summary>
    /// Часть 2 п 2 Подготовить в приложении сущности согласно созданной ранее базе данных. 
    /// </summary>
    [Table("book_genre")]
    public class BookGenre:BaseEntity
    {
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("genre_id")]
        public int GenreId { get; set; }

        public Book Book { get; set; }
        public  Genre Genre { get; set; }
    }
}
