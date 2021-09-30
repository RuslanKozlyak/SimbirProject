using Data.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class HumanMap
    {
        /// <summary>
        ///Реализовать все связи между таблицами, которые присутствуют в схеме.
        /// </summary>
        public HumanMap(EntityTypeBuilder<Human> entityBuilder)
        {
            entityBuilder.HasKey(human => human.Id);
            entityBuilder.Property(human => human.FirstName).IsRequired();
            entityBuilder.Property(human => human.LastName).IsRequired();
            entityBuilder.Property(human => human.MiddleName);
            entityBuilder.Property(human => human.Birthday);
            entityBuilder.Property(human => human.AddedDate);
            entityBuilder.Property(human => human.ModifiedDate);
            entityBuilder.Property(human => human.Version).IsRowVersion();
        }
    }
}
