using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class LibraryCardMap
    {
        public LibraryCardMap(EntityTypeBuilder<LibraryCard> entityBuilder)
        {
            entityBuilder.Property(lc => lc.HumanId).IsRequired();
            entityBuilder.Property(lc => lc.BookId).IsRequired();
        }
    }
}
