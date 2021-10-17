using Domain.DTO.BookDtos;
using System.Collections.Generic;

namespace Domain.DTO.HumanDtos
{
    /// <summary>
    /// Часть 2. п.2.1 Создание класса репрезентирующего человека
    /// Часть 2.2 п.1 Добавление валицации, все поля NotNull
    /// </summary>
    public class HumanDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string? Birthday { get; set; }

        public List<BookDto> Books { get; set; }
    }
}
