using Domain.Data;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entities;

        public Repository(DataContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;
            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }
            return query.AsEnumerable();
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
                throw new Exception($"User with Id {entity.Id} not found");
            }
            entity.AddedDate = DateTimeOffset.UtcNow;
            entity.ModifiedDate = DateTimeOffset.UtcNow;
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new Exception($"User with Id {entity.Id} not found");
            }
            entity.ModifiedDate = DateTimeOffset.UtcNow;
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (Get(entity.Id) != null)
            {
                _entities.Remove(entity);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"User with Id {entity.Id} not found");
            }
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
