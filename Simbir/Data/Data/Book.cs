using Data;
using Data.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DTO
{
    [Table("book")]
    public class Book : BaseEntity
    {
        /// <summary>
        /// Часть 2. п.2.2 Создание класса репрезентирующего книгу
        /// Часть 2.2 п.1 Добавление валицации, все поля NotNull
        /// </summary>
        [Column("name")]
        public string Title { get; set; }
        [Column("author_id")]
        public int AuthorId { get; set; }

        [NotMapped]
        public Author Author { get; set; }
        [NotMapped]
        public ICollection<BookGenre> BookGenre { get; set; }
        [NotMapped]
        public ICollection<LibraryCard> LibraryCard { get; set; }
    }
}
