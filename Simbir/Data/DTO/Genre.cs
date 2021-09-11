
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class Genre : BaseEntity
    {
        public string GenreName { get; set; }
        [NotMapped]
        public virtual BookGenre BookGenre { get; set; }

    }
}
