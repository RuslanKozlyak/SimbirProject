using Data.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class BookGenreMap
    {
        public BookGenreMap(EntityTypeBuilder<BookGenre> entityBuilder)
        {
            entityBuilder.HasNoKey();
            entityBuilder.Property(bookGenre => bookGenre.BookId).IsRequired();
            entityBuilder.Property(bookGenre => bookGenre.GenreId).IsRequired();
            
        }
    }
}
