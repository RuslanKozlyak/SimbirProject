using Data.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class BookMap
    {
        /// <summary>
        ///Реализовать все связи между таблицами, которые присутствуют в схеме.
        /// </summary>
        public BookMap(EntityTypeBuilder<Book> entityBuilder)
        {
            entityBuilder.HasKey(book => book.Id);
            entityBuilder.Property(book => book.Title).IsRequired();
            entityBuilder.Property(book => book.AuthorId).IsRequired();
            entityBuilder.Property(book => book.YearOfWriting);
            entityBuilder.Property(book => book.AddedDate);
            entityBuilder.Property(book => book.ModifiedDate);
            entityBuilder.Property(book => book.Version).IsRowVersion();

            entityBuilder.HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId);
        }
    }
}
