using Domain.Data;
using System.Linq;

namespace Domain.RepositoryInterfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public IQueryable<Genre> GetAllGenres();
        public Genre GetGenre(int genreId);
    }
}
