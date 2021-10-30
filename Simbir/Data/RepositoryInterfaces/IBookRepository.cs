using Domain.Data;
using System.Linq;

namespace Domain.RepositoryInterfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        public IQueryable<Book> GetAllBooks();
        public Book GetBook(int bookId);
    }
}
