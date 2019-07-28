using System;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class QuotesRepository : DbRepository<Quotes>, IQuotesRepository
    {
        public QuotesRepository(GalleryAppContext context)
            : base(context)
        {
        }
    }
}
