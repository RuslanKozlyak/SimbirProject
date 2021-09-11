using Data;
using Data.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DTO
{
    public class Book : BaseEntity
    {
        /// <summary>
        /// Часть 2. п.2.2 Создание класса репрезентирующего книгу
        /// Часть 2.2 п.1 Добавление валицации, все поля NotNull
        /// </summary>

        [Required]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [NotMapped]
        public Author Author { get; set; }
        [NotMapped]
        public BookGenre BookGenre { get; set; }
    }
}
