using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;

namespace GalleryApplication.Data
{
    public class DbDeletableRepository<TEntity> : DbRepository<TEntity>, IDeletableRepository<TEntity>
        where TEntity : class, ICreatable, IDeletable
    {
        private readonly GalleryAppContext context;

        public DbDeletableRepository(GalleryAppContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            await this.UpdateAsync(entity);
        }

        public async Task UnDeleteAsync(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;
            await this.UpdateAsync(entity);
        }

        public override IEnumerable<TEntity> AllEnum()
        {
            return this.context.Set<TEntity>().AsEnumerable()
                .Where(x => x.IsDeleted == false);
        }
    }
}
