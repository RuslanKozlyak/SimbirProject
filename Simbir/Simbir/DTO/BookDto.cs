using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbir.DTO
{
    public class BookDto
    {
        public string Title { get; set; }
        public HumanDto Author { get; set; }
        public string Genre { get; set; }
    }
}
