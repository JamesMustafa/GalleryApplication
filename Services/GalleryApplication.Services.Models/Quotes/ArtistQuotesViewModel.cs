using System;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Mapping;

namespace GalleryApplication.Services.Models.Quotes
{
    public class ArtistQuotesViewModel : IMapFrom<Quote>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ArtistName { get; set; }
    }
}
