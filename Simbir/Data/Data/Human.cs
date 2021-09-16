using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DTO
{
    [Table("person")]
    public class Human : BaseEntity
    {
        /// <summary>
        /// Часть 2. п.2.1 Создание класса репрезентирующего человека
        /// Часть 2.2 п.1 Добавление валицации, все поля NotNull
        /// </summary>
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("middle_name")]
        public string MiddleName { get; set; }
        [Column("birth_date")]
        public string Birthday { get; set; }

        [NotMapped]
        public ICollection<LibraryCard> LibraryCard { get; set; }
    }
}
