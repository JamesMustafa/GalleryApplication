using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GalleryApplication.Data.Common;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GalleryApplication.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity>
        where TEntity : class,ICreatable
    {
        private readonly GalleryAppContext context;


        public DbRepository(GalleryAppContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            await this.context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> GetByIdAsync<T>(T id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task HardDeleteAsync(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public IQueryable<TEntity> All()
        {
            return this.context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> AllEnum()
        {
            return this.context.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            return this.context.Set<TEntity>().AsQueryable().Where(where);
        }
    }
}
