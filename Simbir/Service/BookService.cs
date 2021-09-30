using Data.DTO;
using Repository;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class BookService : IBookService
    {
        private IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public IEnumerable<Book> GetAuthorBooks(int authorId)
        {
            return _bookRepository.GetAll().Where(book => book.AuthorId == authorId);
        }

        public Book GetBook(int bookId)
        {
            return _bookRepository.Get(bookId);
        }

        public IEnumerable<Book> GetSortedBy(string sortBy)
        {
            switch (sortBy.ToString().ToUpper())
            {
                case "AUTHOR":
                    return _bookRepository.GetAll().OrderBy(book => book.Author);
                case "TITLE":
                    return _bookRepository.GetAll().OrderBy(book => book.Title);
                case "GENRE":
                    return _bookRepository.GetAll().OrderBy(book => book.BookGenre);
            }
            return null;
        }

        public Book AddBook(Book book)
        {
            _bookRepository.Insert(book);
            return _bookRepository.Get(book.Id);
        }

        public void DeleteBook(Book book)
        {
            _bookRepository.Remove(book);
        }

        public Book UpdateBook(Book book)
        {
            _bookRepository.Update(book);
            return _bookRepository.Get(book.Id);
        }
    }
}
