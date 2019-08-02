using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public interface IQuotesRepository : IRepository<Quote>
    {
        Task<IEnumerable<Quote>> GetQuotesByArtistIdAsync(int artistId);
    }
}
