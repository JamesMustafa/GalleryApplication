using System;
using System.ComponentModel.DataAnnotations;

namespace GalleryApplication.Web.Models.Quotes
{
    public class CreateQuoteInputModel
    {
        [Required]
        public string Content { get; set; }

        [ValidArtistId]
        public int ArtistId { get; set; }
    }
}
