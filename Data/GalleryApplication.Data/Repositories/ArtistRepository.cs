using System;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class ArtistRepository : DbRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(GalleryAppContext context)
            : base(context)
        {
        }
    }
}
