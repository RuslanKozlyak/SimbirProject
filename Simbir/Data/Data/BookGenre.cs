
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO 
{
    [Table("book_genre")]
    public class BookGenre:BaseEntity
    {
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("genre_id")]
        public int GenreId { get; set; }

        [NotMapped]
        public Book Book { get; set; }
        [NotMapped]
        public  Genre Genre { get; set; }
    }
}
