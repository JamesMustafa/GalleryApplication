using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class ArtRepository : DbDeletableRepository<Art>, IArtRepository
    {
        public ArtRepository(GalleryAppContext context)
            : base(context)
        {
        }

        public async Task<Art> GetArtByIdAsync(Guid id)
        {
            var art = await this.GetByIdAsync(id);

            return await Task.FromResult(art);
        }

        public async Task<IEnumerable<Art>> GetArtsByArtistIdAsync(int artistId)
        {
            var arts = this.AllEnum()
                .Where(x => x.ArtistId == artistId);

            return await Task.FromResult(arts);
        }

        public async Task<IEnumerable<Art>> GetArtsByCategoryIdAsync(int categoryId)
        {
            var arts = this.AllEnum()
                .Where(x => x.CategoryId == categoryId);

            return await Task.FromResult(arts);
        }

        public async Task<IEnumerable<Art>> GetRandomArtsAsync(int count)
        {
            var arts = this.AllEnum()
                .OrderBy(x => Guid.NewGuid())
                .Take(count);

            return await Task.FromResult(arts);
        }
    }
}
