using Domain.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.RepositoryInterfaces
{
    /// <summary>
    /// Часть 2 п 6 Реализовать репозитории под все сущности кроме референсных
    /// </summary>
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        T Get(int id, params Expression<Func<T, object>>[] includes);
        void Insert(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
