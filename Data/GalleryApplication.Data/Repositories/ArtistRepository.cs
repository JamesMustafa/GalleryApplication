using System;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class ArtistRepository : DbRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(GalleryAppContext context)
            : base(context)
        {
        }

        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            var artist = await this.GetByIdAsync(id);
            return artist;
        }

        public bool IsArtistIdValid(int artistId)
        {
            return this.All().Any(x => x.Id == artistId);
        }
    }
}
