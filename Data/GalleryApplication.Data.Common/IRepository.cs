using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GalleryApplication.Data.Common
{
    public interface IRepository<TEntity>
        where TEntity : class, ICreatable
    { 
        Task<TEntity> GetByIdAsync<T>(T id);
        IQueryable<TEntity> All();
        IEnumerable<TEntity> AllEnum();

        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task HardDeleteAsync(TEntity entity);

        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where);

    }
}
