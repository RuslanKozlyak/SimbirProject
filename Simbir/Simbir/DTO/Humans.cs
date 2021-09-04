using System.Collections.Generic;

namespace Simbir.DTO
{
    public class Humans
    {
        static List<HumanDto> listOfHumans = new List<HumanDto>
        {
            new HumanDto { FullName = "Александр Сергеевич Пушкин", Birthday = "06.06.1799" },
            new HumanDto { FullName = "Лев Николаевич Толстой", Birthday = "28.08.1828" },
            new HumanDto { FullName = "Иван Иванович Иванов", Birthday = "01.01.2001" }
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
