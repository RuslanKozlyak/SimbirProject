using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    /// <summary>
    ///Реализовать все связи между таблицами, которые присутствуют в схеме.
    /// </summary>
    public class HumanConfiguration : IEntityTypeConfiguration<Human>
    {
        public void Configure(EntityTypeBuilder<Human> entityBuilder)
        {
            entityBuilder.ToTable("person");
            entityBuilder.HasKey(human => human.Id);
            entityBuilder.Property(human => human.FirstName).IsRequired().HasColumnName("first_name");
            entityBuilder.Property(human => human.LastName).IsRequired().HasColumnName("last_name");
            entityBuilder.Property(human => human.MiddleName).HasColumnName("middle_name");
            entityBuilder.Property(human => human.Birthday).HasColumnName("birth_date");
            entityBuilder.Property(human => human.AddedDate).HasColumnName("added_date");
            entityBuilder.Property(human => human.ModifiedDate).HasColumnName("modified_date");
            entityBuilder.Property(human => human.Version).IsRowVersion().HasColumnName("version");
        }
    }
}
