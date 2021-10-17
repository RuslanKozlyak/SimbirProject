using Domain.Data;
using Domain.RepositoryInterfaces;
using System.Linq;

namespace Repository.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext context)
            : base(context)
        {

        }

        public IQueryable<Book> GetAllBooks()
        {
            return GetAll(include => include.Author, include => include.Genres, include => include.Humans);
        }

        public Book GetBook(int bookId)
        {
            return Get(bookId, include => include.Author, include => include.Genres, include => include.Humans);
        }
    }
}
