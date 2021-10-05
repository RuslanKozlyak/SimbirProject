using Domain.Data;
using Domain.RepositoryInterfaces;
using System.Linq;

namespace Repository.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DataContext context)
            : base(context)
        {

        }

        public IQueryable<Author> GetAllAuthors()
        {
            return GetAll(include => include.Books);
        }

        public Author GetAuthor(int authorId)
        {
            return Get(authorId, include => include.Books);
        }
    }
}
