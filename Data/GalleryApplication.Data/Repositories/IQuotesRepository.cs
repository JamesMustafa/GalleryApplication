using System;
using System.Collections.Generic;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public interface IQuotesRepository : IRepository<Quote>
    {
        IEnumerable<Quote> GetQuotesByArtistId(int id);
    }
}
