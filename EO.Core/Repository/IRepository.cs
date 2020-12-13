using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EO.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Save();
        TEntity Get(Expression<Func<TEntity, bool>> filter = null);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Find(int id);
        IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes);
    }
}
