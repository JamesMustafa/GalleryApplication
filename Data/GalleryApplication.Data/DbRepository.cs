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

        public Task AddAsync(TEntity entity)
        {
            return this.context.Set<TEntity>().AddAsync(entity);
        }

        public IEnumerable<TEntity> All()
        {
            return this.context.Set<TEntity>().ToList();
        }

        public void Delete(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
        }

        public TEntity Get<T>(T id)
        {
            return context.Set<TEntity>().Find(id);
        }
    }
}
