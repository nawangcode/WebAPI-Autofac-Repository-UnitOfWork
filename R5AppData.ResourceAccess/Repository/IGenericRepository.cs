using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace R5AppData.ResourceAccess.Repository
{
    public interface IGenericRepository<TEntity> 
    {
        IEnumerable<TEntity> Get(
                  Expression<Func<TEntity, bool>> filter = null,
                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                  string includeProperties = "");
        TEntity GetById(object id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
    }
}
