using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Models.Quotes;

namespace GalleryApplication.Services.DataServices
{
    public class QuotesService : IQuotesService
    {
        private readonly IRepository<Quote> quotesRepository;

        public QuotesService(IRepository<Quote> quotesRepository)
        {
            this.quotesRepository = quotesRepository;
        }

        public async Task<int> CreateAsync(string content,int artistId)
        {
            var quote = new Quote
            {
                Content = content,
                ArtistId = artistId
            };

            await this.quotesRepository.AddAsync(quote);

            return quote.Id;

        }

        public IEnumerable<ArtistQuotesViewModel> GetRandomQuotes(int count)
        {
             var quotes = this.quotesRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .Select(x => new ArtistQuotesViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    ArtistName = x.Artist.Name

                }).Take(count).ToList();

            return quotes;
        }
    }
}
