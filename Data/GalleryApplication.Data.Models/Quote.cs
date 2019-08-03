using System;
using GalleryApplication.Data.Common;

namespace GalleryApplication.Data.Models
{
    public class Quote : BaseDeletableModel<int>
    {
        public string Content { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
