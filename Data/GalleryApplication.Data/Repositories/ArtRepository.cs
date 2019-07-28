using System;
using System.Collections.Generic;
using System.Linq;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class ArtRepository : DbRepository<Arts>, IArtRepository
    {
        public ArtRepository(GalleryAppContext context)
            : base(context)
        {
        }

        public Arts GetArtByid(Guid id)
        {
            return this.Get(id);
        }

        public IEnumerable<Arts> GetArtsByCategoryId(int id)
        {
            var arts = this.All()
                .Where(x => x.CategoryId == id)
                .ToList();

            return arts;
        }

        public IEnumerable<Arts> GetRandomArts(int count)
        {
            var arts = this.All()
                .OrderBy(x => Guid.NewGuid())
                .Take(count).ToList();

            return arts;
        }
    }
}
