using Domain.Data;
using Domain.RepositoryInterfaces;
using System.Linq;

namespace Repository.Repositories
{
    public class HumanRepository : GenericRepository<Human>, IHumanRepository
    {
        public HumanRepository(DataContext context)
            : base(context)
        {

        }

        public IQueryable<Human> GetAllHumans()
        {
            return GetAll(include => include.Books);
        }

        public Human GetHuman(int humanId)
        {
            return Get(humanId, include => include.Books);
        }
    }
}
