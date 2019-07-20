using System;
using System.Collections.Generic;
using GalleryApplication.Data.Common;

namespace GalleryApplication.Data.Models
{
    public class Artist : BaseModel<int>
    {
        public string Name { get; set; }
        public string shortBiography { get; set; }
        public IEnumerable<Quotes> Quotes { get; set; }
    }
}
