using Data.DTO;
using Repository;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class BookGenreService : IBookGenreService
    {
        private IRepository<BookGenre> _bgRepository;
        public BookGenreService(IRepository<BookGenre> bgRepository)
        {
            _bgRepository = bgRepository;
        }

        public IEnumerable<BookGenre> GetAllBookGenres()
        {
            return _bgRepository.GetAll();
        }

        public IEnumerable<BookGenre> GetBookGenre(int genreId)
        {
            return _bgRepository.GetAll().Where(lc => lc.BookId == genreId);
        }

        public void AddBookGenre(BookGenre bookGenre)
        {
            _bgRepository.Insert(bookGenre);
        }

        public void DeleteBookGenre(BookGenre bookGenre)
        {
            _bgRepository.Remove(bookGenre);
        }

        public void UpdateBookGenre(BookGenre bookGenre)
        {
            _bgRepository.Update(bookGenre);
        }
    }
}
