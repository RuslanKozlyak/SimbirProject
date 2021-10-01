using System;
using System.Collections.Generic;

namespace Domain.Data
{
    /// <summary>
    /// Часть 2 п 2 Подготовить в приложении сущности согласно созданной ранее базе данных. 
    /// </summary>
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int? YearOfWriting { get; set; }

        public Author Author { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Human> Humans { get; set; }
    }
}
