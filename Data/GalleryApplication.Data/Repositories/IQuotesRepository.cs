using System;
using System.Collections.Generic;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public interface IQuotesRepository : IRepository<Quotes>
    {
        IEnumerable<Quotes> GetQuotesByArtistId(int id);
    }
}
