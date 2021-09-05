using System.Collections.Generic;
using System.Linq;

namespace Simbir.DTO
{
    public class Humans
    {
        /// <summary>
        /// Часть 2. п.2.3 Создание статичного списка людей
        /// </summary>
        static List<HumanDto> listOfHumans = new List<HumanDto>
        {
            new HumanDto {Id = 1, FullName = "Александр Сергеевич Пушкин", Birthday = "06.06.1799" },
            new HumanDto {Id = 2, FullName = "Лев Николаевич Толстой", Birthday = "28.08.1828" },
            new HumanDto {Id = 3, FullName = "Иван Алексеевич Гончаров", Birthday = "18.06.1812" },
            new HumanDto {Id = 4, FullName = "Иван Иванович Иванов", Birthday = "01.01.2001" }
        };
        public static List<HumanDto> HumansList
        {
            get
            {
                return listOfHumans;
            }
            set
            {
                listOfHumans = value;
            }
        }
        public static IEnumerable<HumanDto> GetAll()
        {
            return Humans.HumansList;
        }

        public static IEnumerable<HumanDto> GetAuthors()
        {
            return Humans.HumansList.Where(human => Books.AreAuthor(human));
        }

        public static HumanDto GetContainingQuery(string query)
        {
            foreach (var human in HumansList)
            {
                if (human.FullName.Contains(query))
                    return human;
            }
            return null;
        }
        public static HumanDto FindHuman(HumanDto human)
        {
            foreach (var element in HumansList)
            {
                if (human.FullName == element.FullName & human.Birthday == element.Birthday)
                    return element;
                break;
            }
            return null;
        }
    }
}
