using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public interface IArtRepository : IRepository<Arts>
    {
        Task<IEnumerable<Arts>> GetRandomArtsAsync(int count);

        Task<IEnumerable<Arts>> GetArtsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Arts>> GetArtsByArtistIdAsync(int artistId);

        Task<Arts> GetArtByIdAsync(Guid id);
    }
}
