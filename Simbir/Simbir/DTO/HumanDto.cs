using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simbir.DTO
{
    public class HumanDto
    {
        /// <summary>
        /// Часть 2. п.2.1 Создание класса репрезентирующего человека
        /// Часть 2.2 п.1 Добавление валицации, все поля NotNull
        /// </summary>
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string Birthday { get; set; }
    }
}
