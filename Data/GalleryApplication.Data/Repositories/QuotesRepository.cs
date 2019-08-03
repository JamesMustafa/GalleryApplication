using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class QuotesRepository : DbDeletableRepository<Quote>, IQuotesRepository
    {
        public QuotesRepository(GalleryAppContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Quote>> GetQuotesByArtistIdAsync(int artistId)
        {
            var quotes = this.AllEnum()
                .Where(x => x.ArtistId == artistId);

            return await Task.FromResult(quotes);
        }
    }
}
