using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryApplication.Data.Common
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity Get<T>(T id);
        IEnumerable<TEntity> All();

        Task AddAsync(TEntity entity);

        void Delete(TEntity entity);

    }
}
