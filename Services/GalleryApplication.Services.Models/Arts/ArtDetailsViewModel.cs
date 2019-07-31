﻿using System;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Mapping;

namespace GalleryApplication.Services.Models.Arts
{
    public class ArtDetailsViewModel : IMapFrom<Art>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string ArtistName { get; set; }
        public int ArtistId { get; set; }
        public DateTime UploadedOn { get; set; }
    }
}
