using System;
using GalleryApplication.Data.Common;

namespace GalleryApplication.Data.Models
{
    public class Arts : BaseModel<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UploadedOn { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
