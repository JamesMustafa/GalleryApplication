using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GalleryApplication.Data.Common;
using System.Collections.Generic;

namespace GalleryApplication.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly GalleryAppContext context;

        public DbRepository(GalleryAppContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
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

        public async Task DeleteAsync(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> All()
        {
            return this.context.Set<TEntity>().ToList();
        }
    }
}
