using System;
using GalleryApplication.Data.Common;

namespace GalleryApplication.Data.Models
{
    public class Quote : BaseModel<int>
    {
        public string Content { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
