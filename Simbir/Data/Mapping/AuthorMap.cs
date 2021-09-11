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
        public AuthorMap(EntityTypeBuilder<Author> entityBuilder)
        {
            entityBuilder.HasKey(author => author.Id);
            entityBuilder.Property(author => author.FirstName).IsRequired();
            entityBuilder.Property(author => author.LastName).IsRequired();
            entityBuilder.Property(author => author.MiddleName);
        }
    }
}
