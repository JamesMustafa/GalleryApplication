using System;
using System.Threading.Tasks;

namespace GalleryApplication.Data.Common
{
    public interface IDeletableRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, ICreatable, IDeletable
    {
        Task DeleteAsync(TEntity entity);

        Task UnDeleteAsync(TEntity entity);
    }
}
