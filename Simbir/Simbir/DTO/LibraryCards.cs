using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbir.DTO
{
    public class LibraryCards
    {
        /// <summary>
        /// ЧАсть 2.1 Создание статичного списка библиотечных карточек
        /// </summary>
        private static List<LibraryCardDto> _libraryCardList = new List<LibraryCardDto>();
        public static List<LibraryCardDto> LibraryCardsList
        {
            get 
            {
                return _libraryCardList; 
            }
            set 
            { 
                _libraryCardList = value; 
            }
        }
    }
}
