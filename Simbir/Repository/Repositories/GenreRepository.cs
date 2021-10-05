using Domain.Data;
using Domain.RepositoryInterfaces;
using System.Linq;

namespace Repository.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DataContext context)
            : base(context)
        {

        }

        public IQueryable<Genre> GetAllGenres()
        {
            return GetAll(include => include.Books);
        }

        public Genre GetGenre(int genreId)
        {
            return Get(genreId, include => include.Books);
        }
    }
}
