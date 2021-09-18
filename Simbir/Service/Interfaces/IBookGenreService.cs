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
        public IEnumerable<BookGenre> GetBookGenre(int bookId);
        public BookGenre AddGenreBook(Book book, Genre genre);
        public void DeleteBookGenre(Book book, Genre genre);
        public BookGenre UpdateBookGenre(Book book, Genre genre);
    }
}
