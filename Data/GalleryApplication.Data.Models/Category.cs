using System;
using GalleryApplication.Data.Common;

namespace GalleryApplication.Data.Models
{
    public class Category : BaseModel<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
