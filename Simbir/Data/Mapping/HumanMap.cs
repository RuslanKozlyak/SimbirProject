using Data.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class HumanMap
    {
        public HumanMap(EntityTypeBuilder<Human> entityBuilder)
        {
            entityBuilder.HasKey(human => human.Id);
            entityBuilder.Property(human => human.FirstName).IsRequired();
            entityBuilder.Property(human => human.LastName).IsRequired();
            entityBuilder.Property(human => human.MiddleName);
            entityBuilder.Property(human => human.Birthday);
            entityBuilder.HasOne(lc => lc.LibraryCard)
                .WithOne(human => human.Human)
                .HasForeignKey<Human>(human => human.Id);
        }
    }
}
