using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Models.Quotes;

namespace GalleryApplication.Services.DataServices
{
    public interface IQuotesService
    {
        IEnumerable<ArtistQuotesViewModel> GetRandomQuotes(int count);

        Task<int> CreateAsync(string content,int artistId);
    }
}
