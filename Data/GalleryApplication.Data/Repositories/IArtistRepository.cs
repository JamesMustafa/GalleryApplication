using System;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        bool IsArtistIdValid(int artistId);

        Task<Artist> GetArtistByIdAsync(int id);
    }
}
