using System;
using System.Collections.Generic;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Mapping;
using GalleryApplication.Services.Models.Home;

namespace GalleryApplication.Services.Models.Categories
{
    public class CategoryDetailsViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<IndexArtsViewModel> Arts { get; set; }
    }
}
