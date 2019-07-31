using System;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Mapping;

namespace GalleryApplication.Services.Models
{
    public class IdAndNameViewModel : IMapFrom<Artist>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
