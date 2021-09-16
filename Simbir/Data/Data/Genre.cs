
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    [Table("genre")]
    public class Genre : BaseEntity
    {
        [Column("genre_name")]
        public string GenreName { get; set; }

        [NotMapped]
        public ICollection<BookGenre>BookGenre { get; set; }
    }
}
