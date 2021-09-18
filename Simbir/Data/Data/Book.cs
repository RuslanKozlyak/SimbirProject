using Data;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DTO
{
    /// <summary>
    /// Часть 2 п 2 Подготовить в приложении сущности согласно созданной ранее базе данных. 
    /// </summary>
    [Table("book")]
    public class Book : BaseEntity
    {
        [Column("name")]
        public string Title { get; set; }
        [Column("author_id")]
        public int AuthorId { get; set; }
        [Column("year_of_writing")]
        public DateTime? YearOfWriting { get; set; }

        public Author Author { get; set; }
        public ICollection<BookGenre> BookGenre { get; set; }
        public ICollection<LibraryCard> LibraryCard { get; set; }
    }
}
