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
        /// <summary>
        ///Реализовать все связи между таблицами, которые присутствуют в схеме.
        /// </summary>
        public BookGenreMap(EntityTypeBuilder<BookGenre> entityBuilder)
        {
            entityBuilder.HasKey(bookGenre => bookGenre.Id);
            entityBuilder.Property(bookGenre => bookGenre.BookId).IsRequired();
            entityBuilder.Property(bookGenre => bookGenre.GenreId).IsRequired();
            entityBuilder.Property(bookGenre => bookGenre.AddedDate);
            entityBuilder.Property(bookGenre => bookGenre.ModifiedDate);
            entityBuilder.Property(bookGenre => bookGenre.Version);

            entityBuilder.HasOne(book => book.Book)
                .WithMany(bookGenre => bookGenre.BookGenre)
                .HasForeignKey(book => book.BookId);
            entityBuilder.HasOne(genre => genre.Genre)
                .WithMany(bookGenre => bookGenre.BookGenre)
                .HasForeignKey(book => book.GenreId);
        }
    }
}
