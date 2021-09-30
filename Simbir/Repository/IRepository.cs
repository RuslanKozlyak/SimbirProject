using Data;
using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
