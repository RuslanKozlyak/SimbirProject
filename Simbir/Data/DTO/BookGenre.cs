
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO 
{
    public class BookGenre
    {
        public int BookId { get; set; }
        [NotMapped]
        public ICollection<Book> Books { get; set; }
        public int GenreId { get; set; }
        [NotMapped]
        public  ICollection<Genre> Genres { get; set; }
    }
}
