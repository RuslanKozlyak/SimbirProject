using Data.DTO;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IBookService
    {
        public IEnumerable<Book> GetAllBooks();
        public Book GetBook(int bookId);
        public IEnumerable<Book> GetAuthorBooks(int authorId);
        public IEnumerable<Book> GetSortedBy(string sortBy);
        public void AddBook(Book book);
        public void DeleteBook(Book book);

    }
}
