using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Neo4jRepository
{
    public interface IRepository<TEntity> where TEntity : IEntity, new()
    {
        Task<IEnumerable<TEntity>> All();
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> query);
        Task<TEntity> Single(Expression<Func<TEntity, bool>> query);
        Task Add(TEntity item);
        Task Update(Expression<Func<TEntity, bool>> query, TEntity item);
        Task Delete(Expression<Func<TEntity, bool>> query);
    }
}
