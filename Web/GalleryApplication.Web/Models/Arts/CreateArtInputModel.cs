using System;
using System.ComponentModel.DataAnnotations;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Mapping;

namespace GalleryApplication.Web.Models.Arts
{
    public class CreateArtInputModel : IMapFrom<Art>
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }

        [ValidArtistId]
        public int ArtistId { get; set; }
    }
}
