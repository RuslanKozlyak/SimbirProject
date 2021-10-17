using Domain.Data;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;

            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public T Get(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;

            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }

            var findedEntity = query.FirstOrDefault(s => s.Id == id);

            if (findedEntity == null)
            {
                throw new Exception($"User with Id {id} not found");
            }

            return findedEntity;
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            var now = DateTimeOffset.UtcNow;
            entity.AddedDate = now;
            entity.ModifiedDate = now;
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            entity.ModifiedDate = DateTimeOffset.UtcNow;
            _entities.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            var obj = _entities.Where(_entity => _entity.Id == entity.Id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            else if (obj != null)
            {
                
                _entities.Remove(entity);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"User with Id {entity.Id} not found");
            }
        }
    }
}
