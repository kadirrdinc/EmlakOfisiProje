using EO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EO.Core.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly EOContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(EOContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public TEntity Find(int id)
        {
            return _dbSet.Find(id);

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            var entity = _dbSet.Where(filter).FirstOrDefault();
            return entity;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            var entity = filter == null ? _dbSet.ToList() : _dbSet.Where(filter).ToList();
            return entity;
        }

        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            return query;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}
