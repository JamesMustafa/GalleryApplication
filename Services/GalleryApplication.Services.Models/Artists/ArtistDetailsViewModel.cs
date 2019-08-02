using System;
using System.Collections.Generic;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Models.Home;
using GalleryApplication.Services.Models.Quotes;

namespace GalleryApplication.Services.Models.Artists
{
    public class ArtistDetailsViewModel
    {
        public string Name { get; set; }
        public string ShortBiography { get; set; }
        public IEnumerable<ArtistQuotesViewModel> Quotes { get;set; }
        public IEnumerable<IndexArtsViewModel> Arts { get; set; }
    }
}
