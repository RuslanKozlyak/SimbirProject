using Data.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class GenreMap
    {
        /// <summary>
        ///Реализовать все связи между таблицами, которые присутствуют в схеме.
        /// </summary>
        public GenreMap(EntityTypeBuilder<Genre> entityBuilder)
        {
            entityBuilder.HasKey(genre => genre.Id);
            entityBuilder.Property(genre => genre.GenreName).IsRequired();
            entityBuilder.Property(genre => genre.AddedDate);
            entityBuilder.Property(genre => genre.ModifiedDate);
            entityBuilder.Property(genre => genre.Version).IsRowVersion();
        }
    }
}
