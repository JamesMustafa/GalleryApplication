using System;
using System.Collections.Generic;
using System.Linq;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class QuotesRepository : DbRepository<Quotes>, IQuotesRepository
    {
        public QuotesRepository(GalleryAppContext context)
            : base(context)
        {
        }

        public IEnumerable<Quotes> GetQuotesByArtistId(int id)
        {
            var quotes = this.All()
                .Where(x => x.ArtistId == id)
                .ToList();

            return quotes;
        }
    }
}
