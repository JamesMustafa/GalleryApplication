using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryApplication.Data.Common
{
    public interface IRepository<TEntity>
        where TEntity : class
    { 
        Task<TEntity> GetByIdAsync<T>(T id);
        IQueryable<TEntity> All();
        IEnumerable<TEntity> AllEnum();

        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

    }
}
