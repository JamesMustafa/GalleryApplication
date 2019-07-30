using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class ArtRepository : DbRepository<Arts>, IArtRepository
    {
        public ArtRepository(GalleryAppContext context)
            : base(context)
        {
        }

        public async Task<Arts> GetArtByIdAsync(Guid id)
        {
            var art = await this.GetByIdAsync(id);

            return await Task.FromResult(art);
        }

        public async Task<IEnumerable<Arts>> GetArtsByArtistIdAsync(int artistId)
        {
            var arts = this.All()
                .Where(x => x.ArtistId == artistId)
                .ToList();

            return await Task.FromResult<IEnumerable<Arts>>(arts);
        }

        public async Task<IEnumerable<Arts>> GetArtsByCategoryIdAsync(int categoryId)
        {
            var arts = this.All()
                .Where(x => x.CategoryId == categoryId)
                .ToList();

            return await Task.FromResult<IEnumerable<Arts>>(arts);
        }

        public async Task<IEnumerable<Arts>> GetRandomArtsAsync(int count)
        {
            var arts = this.All()
                .OrderBy(x => Guid.NewGuid())
                .Take(count).ToList();

            return await Task.FromResult<IEnumerable<Arts>>(arts);
        }
    }
}
