using System;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Mapping;

namespace GalleryApplication.Services.Models.Home
{
    public class IndexArtsViewModel : IMapFrom<Art>
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
    }
}
