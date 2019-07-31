using System;
using System.ComponentModel.DataAnnotations;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Mapping;

namespace GalleryApplication.Web.Models.Quotes
{
    public class CreateQuoteInputModel : IMapFrom<Quote>
    {
        [Required]
        public string Content { get; set; }

        [ValidArtistId]
        public int ArtistId { get; set; }
    }
}
