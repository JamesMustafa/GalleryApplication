using System;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Services.Models.Home
{
    public class IndexArtsViewModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
    }
}
