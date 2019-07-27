﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Models.Arts;
using GalleryApplication.Services.Models.Home;

namespace GalleryApplication.Services.DataServices
{
    public interface IArtsService
    {
        IndexArtsViewModel GetOneRandomArt();

        IEnumerable<IndexArtsViewModel> GetRandomArts(int count);

        int GetCount();

        Task<Guid> CreateAsync(Arts arts,DateTime uploadedOn,string extension);

        ArtDetailsViewModel GetArtByid(Guid id);
    }
}
