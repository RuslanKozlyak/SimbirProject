using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbir.DTO
{
    public class LibraryCards
    {
        static List<LibraryCardDto> libraryCardsList = new List<LibraryCardDto>();
        public static List<LibraryCardDto> LibraryCardsList
        {
            get 
            {
                return libraryCardsList; 
            }
            set 
            { 
                libraryCardsList = value; 
            }
        }
    }
}
