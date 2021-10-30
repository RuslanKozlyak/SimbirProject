using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    /// <summary>
    ///Реализовать все связи между таблицами, которые присутствуют в схеме.
    /// </summary>
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> entityBuilder)
        {
            entityBuilder.ToTable("author");
            entityBuilder.HasKey(author => author.Id);
            entityBuilder.Property(author => author.FirstName).IsRequired().HasColumnName("first_name");
            entityBuilder.Property(author => author.LastName).IsRequired().HasColumnName("last_name");
            entityBuilder.Property(author => author.MiddleName).HasColumnName("middle_name");
            entityBuilder.Property(author => author.AddedDate).HasColumnName("added_date");
            entityBuilder.Property(author => author.ModifiedDate).HasColumnName("modified_date");
            entityBuilder.Property(author => author.Version).IsRowVersion().HasColumnName("version");
        }
    }
}
