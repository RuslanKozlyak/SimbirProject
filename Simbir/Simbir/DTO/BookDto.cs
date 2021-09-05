using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simbir.DTO
{
    public class BookDto 
    {
        /// <summary>
        /// Часть 2. п.2.2 Создание класса репрезентирующего книгу
        /// Часть 2.2 п.1 Добавление валицации, все поля NotNull
        /// </summary>
        
        
        [Required]
        public string Title { get; set; }
        [Required]
        public int Author { get; set; }
        [Required]
        public string Genre { get; set; }
    }
}
