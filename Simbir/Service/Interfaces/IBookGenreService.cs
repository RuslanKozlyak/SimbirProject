using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBookGenreService
    {
        public IEnumerable<BookGenre> GetAllBookGenres();
        public IEnumerable<BookGenre> GetBookGenre(int genreId);
        public void AddBookGenre(BookGenre bookGenre);
        public void DeleteBookGenre(BookGenre bookGenre);
        public void UpdateBookGenre(BookGenre bookGenre);
    }
}
