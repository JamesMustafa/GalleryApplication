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
        IEnumerable<TEntity> All();

        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

    }
}
