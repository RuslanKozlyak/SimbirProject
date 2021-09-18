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
        /// <summary>
        ///Реализовать все связи между таблицами, которые присутствуют в схеме.
        /// </summary>
        public LibraryCardMap(EntityTypeBuilder<LibraryCard> entityBuilder)
        {
            entityBuilder.HasKey(lc => lc.Id);
            entityBuilder.Property(lc => lc.HumanId).IsRequired();
            entityBuilder.Property(lc => lc.BookId).IsRequired();
            entityBuilder.Property(lc => lc.Date).IsRequired();
            entityBuilder.Property(lc => lc.AddedDate);
            entityBuilder.Property(lc => lc.ModifiedDate);
            entityBuilder.Property(lc => lc.Version);

            entityBuilder.HasOne(human => human.Human)
                .WithMany(lc => lc.LibraryCard)
                .HasForeignKey(human => human.HumanId);
            entityBuilder.HasOne(book => book.Book)
               .WithMany(lc => lc.LibraryCard)
               .HasForeignKey(book => book.BookId);
        }
    }
}
