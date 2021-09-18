using Data.DTO;
using Repository;
using Service.Interfaces;
using System;
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

        public IEnumerable<BookGenre> GetBookGenre(int bookId)
        {
            return _bgRepository.GetAll().Where(lc => lc.BookId == bookId);
        }

        public BookGenre AddGenreBook(Book book,Genre genre)
        {
            BookGenre bookGenre = new BookGenre
            {
                BookId = book.Id,
                GenreId = genre.Id,
            };
            _bgRepository.Insert(bookGenre);
            return bookGenre;
        }

        public void DeleteBookGenre(Book book, Genre genre)
        {
            try
            {
                var deletedGenre = _bgRepository.GetAll()
                .FirstOrDefault(bookGenre => bookGenre.GenreId == genre.Id & bookGenre.BookId == book.Id);
                _bgRepository.Remove(deletedGenre);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public BookGenre UpdateBookGenre(Book book, Genre genre)
        {
            var updatedGenre = _bgRepository.GetAll()
                .FirstOrDefault(bookGenre => bookGenre.GenreId == genre.Id & bookGenre.BookId == book.Id);
            _bgRepository.Update(updatedGenre);
            return updatedGenre;
        }
    }
}
