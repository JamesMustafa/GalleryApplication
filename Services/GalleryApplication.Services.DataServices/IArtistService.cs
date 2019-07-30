using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApplication.Services.Models;
using GalleryApplication.Services.Models.Artist;

namespace GalleryApplication.Services.DataServices
{
    public interface IArtistService
    {
        bool IsArtistIdValid(int artistId);
        IEnumerable<IdAndNameViewModel> GetAll();
        Task<ArtistDetailsViewModel> GetArtistByIdAsync(int id);
        //can put createasync for administrator role but not now, for now
        //i will put them from the database
    }
}
