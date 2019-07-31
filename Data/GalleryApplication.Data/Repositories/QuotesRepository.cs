using System;
using System.Collections.Generic;
using System.Linq;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class QuotesRepository : DbRepository<Quote>, IQuotesRepository
    {
        public QuotesRepository(GalleryAppContext context)
            : base(context)
        {
        }

        public IEnumerable<Quote> GetQuotesByArtistId(int id)
        {
            var quotes = this.All()
                .Where(x => x.ArtistId == id)
                .ToList();

            return quotes;
        }
    }
}
