using Domain.Data;
using System.Linq;

namespace Domain.RepositoryInterfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        public IQueryable<Author> GetAllAuthors();
        public Author GetAuthor(int authorId);
    }
}
