using System.Collections.Generic;

namespace Domain.Data
{
    /// <summary>
    /// Часть 2 п 2 Подготовить в приложении сущности согласно созданной ранее базе данных. 
    /// </summary>
    public class Genre : BaseEntity
    {
        public string GenreName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
