using System;
using System.Collections.Generic;
using System.Linq;

namespace Simbir.DTO
{
    public class Humans
    {
        /// <summary>
        /// Часть 2. п.2.3 Создание статичного списка людей
        /// </summary>
        private static List<HumanDto> _listOfHumans = new List<HumanDto>();
        public static List<HumanDto> HumanList
        {
            get
            {
                return _listOfHumans;
            }
            set
            {
                _listOfHumans = value;
            }
        }
        public static IEnumerable<HumanDto> GetAll()
        {
            return Humans.HumanList;
        }

        public static IEnumerable<HumanDto> GetAuthors()
        {
            return Humans.HumanList.Where(human => Books.AreAuthor(human));
        }

        public static HumanDto GetContainingQuery(string query)
        {
            return HumanList.FirstOrDefault(human => $"{human.FirstName}{human.LastName}{human.MiddleName}".Contains(query));
        }
        public static HumanDto FindHuman(HumanDto human)
        {
            return HumanList.FirstOrDefault(h => h.Id == human.Id);
        }

        public static string AddHuman(HumanDto human)
        {
            try
            {
                var findedHuman = FindHuman(human);
                if (findedHuman == null)
                {
                    HumanList.Add(findedHuman);
                    return "Человек успешно добавлен!";
                }
                else
                {
                    return "Такой человек уже существует!";
                }

            }
            catch (Exception ex)
            {
                return $"Человек не добавлен! Ошибка: [ {ex.Message} ]";
            }
        }

        public static string DeleteHuman(HumanDto human)
        {
            try
            {
                var findedHuman = FindHuman(human);
                HumanList.Remove(findedHuman);
                return "Человек успешно удален!";
            }
            catch (Exception ex)
            {
                return $"Человек не удален! Ошибка: [ {ex.Message} ]";
            }
        }
    }
}
