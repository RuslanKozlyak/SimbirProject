using Data.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class AuthorMap
    {
        /// <summary>
        ///Реализовать все связи между таблицами, которые присутствуют в схеме.
        /// </summary>
        public AuthorMap(EntityTypeBuilder<Author> entityBuilder)
        {
            entityBuilder.HasKey(author => author.Id);
            entityBuilder.Property(author => author.FirstName).IsRequired();
            entityBuilder.Property(author => author.LastName).IsRequired();
            entityBuilder.Property(author => author.MiddleName);
            entityBuilder.Property(author => author.AddedDate);
            entityBuilder.Property(author => author.ModifiedDate);
            //entityBuilder.Property(author => author.Version);
        }
    }
}
