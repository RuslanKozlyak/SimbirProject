using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    /// <summary>
    ///Реализовать все связи между таблицами, которые присутствуют в схеме.
    /// </summary>
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> entityBuilder)
        {
            entityBuilder.ToTable("book");
            entityBuilder.HasKey(book => book.Id);
            entityBuilder.Property(book => book.Title).IsRequired().HasColumnName("name");
            entityBuilder.Property(book => book.AuthorId).IsRequired().HasColumnName("author_id");
            entityBuilder.Property(book => book.YearOfWriting).HasColumnName("year_of_writing");
            entityBuilder.Property(book => book.AddedDate).HasColumnName("added_date");
            entityBuilder.Property(book => book.ModifiedDate).HasColumnName("modified_date");
            entityBuilder.Property(book => book.Version).IsRowVersion().HasColumnName("version");

            entityBuilder.HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId);
            entityBuilder.HasMany(book => book.Genres)
                .WithMany(genre => genre.Books)
                .UsingEntity(bookGenre => bookGenre.ToTable("book_genre"));
            entityBuilder.HasMany(book => book.Humans)
               .WithMany(human => human.Books)
               .UsingEntity(libraryCard => libraryCard.ToTable("library_card"));
        }
    }
}
