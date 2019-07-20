using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Models.Arts;
using GalleryApplication.Services.Models.Home;

namespace GalleryApplication.Services.DataServices
{
    public interface IArtsService
    {
        IEnumerable<IndexArtsViewModel> GetRandomArts(int count);

        int GetCount();

        Task<Guid> CreateAsync(Arts arts,DateTime uploadedOn);

        ArtDetailsViewModel GetArtByid(Guid id);
    }
}
