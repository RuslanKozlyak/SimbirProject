using Data;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;


namespace Repository
{
    /// <summary>
    /// Часть 2 п 6 Реализовать репозитории под все сущности кроме референсных
    /// </summary>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;

        private DbSet<T> _entities;
        public Repository(DataContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T Get(int id)
        {
            var findedEntity = _entities.FirstOrDefault(s => s.Id == id);
            if (findedEntity == null)
            {
                throw new ArgumentNullException("id");
            }
            return findedEntity;
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.AddedDate = DateTimeOffset.UtcNow;
            entity.ModifiedDate = DateTimeOffset.UtcNow;
            entity.Version = 1;
            _entities.Add(entity);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.ModifiedDate = DateTimeOffset.UtcNow;
            entity.Version++;
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (Get(entity.Id) != null)
            {
                _entities.Remove(entity);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("entity");
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
