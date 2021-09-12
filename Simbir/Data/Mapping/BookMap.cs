using Data.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class BookMap
    {
        public BookMap(EntityTypeBuilder<Book> entityBuilder)
        {
            entityBuilder.HasKey(book => book.Id);
            entityBuilder.Property(book => book.Title).IsRequired();
            entityBuilder.Property(book => book.AuthorId).IsRequired();
            entityBuilder.Property(book => book.AddedDate);
            entityBuilder.Property(book => book.ModifiedDate);

            entityBuilder.HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId);
        }
    }
}
