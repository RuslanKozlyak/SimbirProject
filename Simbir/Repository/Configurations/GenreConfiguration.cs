using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    /// <summary>
    ///Реализовать все связи между таблицами, которые присутствуют в схеме.
    /// </summary>
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> entityBuilder)
        {
            entityBuilder.ToTable("genre");
            entityBuilder.HasKey(genre => genre.Id);
            entityBuilder.Property(genre => genre.GenreName).IsRequired().HasColumnName("genre_name");
            entityBuilder.Property(genre => genre.AddedDate).HasColumnName("added_date");
            entityBuilder.Property(genre => genre.ModifiedDate).HasColumnName("modified_date");
            entityBuilder.Property(genre => genre.Version).IsRowVersion().HasColumnName("version");
        }
    }
}
