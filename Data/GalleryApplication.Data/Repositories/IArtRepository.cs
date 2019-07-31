using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public interface IArtRepository : IRepository<Art>
    {
        Task<IEnumerable<Art>> GetRandomArtsAsync(int count);

        Task<IEnumerable<Art>> GetArtsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Art>> GetArtsByArtistIdAsync(int artistId);

        Task<Art> GetArtByIdAsync(Guid id);
    }
}
