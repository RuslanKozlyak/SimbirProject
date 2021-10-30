using Domain.Data;
using System.Linq;

namespace Domain.RepositoryInterfaces
{
    public interface IHumanRepository : IRepository<Human>
    {
        public IQueryable<Human> GetAllHumans();
        public Human GetHuman(int humanId);
    }
}
